using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private GameObject objCanvasGO;
    private GameObject bulletPool;
    private GameObject bulletPrefab;

    private CircleCollider2D cannonCollider;
    private GameObject range;
    private RectTransform rangeRect;

    private string cannonName = "Cannon";
    private int attackRange = 100;
    private float attackFrequency = 1f;
    private int bulletPower;
    private float bulletSpeed;

    private float attackTimer = 0f;

    public List<GameObject> enemyList = new List<GameObject>();

    private void Awake()
    {
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        bulletPool = objCanvasGO.FindChildGameObject(Functions.NAME_BULLETPOOL);
        bulletPrefab = Functions.PREFAB_BULLET;

        cannonCollider = GetComponent<CircleCollider2D>();
        range = transform.parent.gameObject.FindChildGameObject(Functions.NAME_CANNON_RANGE);
        rangeRect = range.GetComponent<RectTransform>();

        UpgradeCannon();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackFrequency)
        {
            GameObject enemy;
            if (!TryGetTheClosestObject(out enemy))
                return;

            transform.LookAtVector2(enemy.transform, Vector2.up);
            ShotBullet();

            attackTimer = 0f;
        }
    }

    private void ShotBullet()
    {
        GameObject bulletInst = Instantiate(bulletPrefab, bulletPool.transform);
        bulletInst.transform.position = transform.position;
        bulletInst.transform.rotation = transform.rotation;
    }

    private void UpgradeCannon()
    {
        cannonCollider.radius = attackRange * 2;
        rangeRect.sizeDelta = new Vector2(cannonCollider.radius * 2, cannonCollider.radius * 2);//Render Range
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Functions.TAG_ENEMY)
        {
            enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemyList.Contains(collision.gameObject))
        {
            enemyList.Remove(collision.gameObject);
        }
    }

    private bool TryGetTheClosestObject(out GameObject theClosest)
    {
        float minDistance = float.MaxValue;

        theClosest = null;

        if (enemyList.Count == 0)
            return false;

        foreach (var enemy in enemyList)
        {
            if ((transform.position - enemy.transform.position).sqrMagnitude < minDistance)
            {
                theClosest = enemy;
                minDistance = (transform.position - enemy.transform.position).sqrMagnitude;
            }
        }

        return theClosest == null ? false : true;
    }
}