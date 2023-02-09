using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private const int MAX_BULLET_COUNT = 100;

    private static BulletPool instance;
    public static BulletPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS).FindChildGameObject(Functions.NAME_BULLETPOOL).GetComponent<BulletPool>();
            }
            return instance;
        }
    }

    private Stack<GameObject> bulletPool = new Stack<GameObject>();
    private GameObject bulletPrefab;

    private void Awake()
    {
        Initialize();
    }


    private void Initialize()
    {
        bulletPrefab = Functions.PREFAB_BULLET;

        for (int i = 0; i < MAX_BULLET_COUNT; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.name = $"Bullet{i}";
            DisableBullet(bullet);
        }
    }

    public void EnableBullet(Vector2 position, Quaternion rotation)
    {
        GameObject bullet = bulletPool.Count > 0 ? bulletPool.Pop() : Instantiate(bulletPrefab, transform);

        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);

        bullet.name = $"{bullet.name}+{bullet.name}";
    }

    public void DisableBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Push(bullet);
    }
}