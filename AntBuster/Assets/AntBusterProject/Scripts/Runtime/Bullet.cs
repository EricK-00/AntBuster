using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float SPEED = 100f;//4 * 100f;
    private int power = 2;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Setup());
        StartCoroutine(DisableThis());
    }

    private void OnDisable()
    {

    }

    private void Start()
    {

    }

    private IEnumerator Setup()
    {
        yield return new WaitForEndOfFrame();
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * SPEED);

        yield return null;
    }

    private IEnumerator DisableThis()
    {
        yield return new WaitForSeconds(10f);
        BulletPool.Instance.DisableBullet(gameObject);
        //Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Functions.TAG_ENEMY)
        {
            collision.gameObject.GetComponent<Ant>().Damaged(power);
            BulletPool.Instance.DisableBullet(gameObject);
            //Destroy(this);
        }
    }
}