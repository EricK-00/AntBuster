using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Power { get; private set; } = 2;

    private const float SPEED = 100f;
    private Rigidbody2D rb;

    private float maxWidth;
    private float maxHeight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(transform.up * SPEED);

        Debug.Log($"{0 - Screen.width / 2}, {0 + Screen.width / 2}, {0 - Screen.height / 2}, {0 + Screen.height / 2}");
        Debug.Log($"{transform.position}");

        maxWidth = GameManager.Instance.ObjCanvasWidth;
        maxHeight= GameManager.Instance.ObjCanvasHeight;
    }

    private void Update()
    {
        if ((transform.position.x < 0 - maxWidth / 2) || 
            (transform.position.x > 0 + maxWidth / 2) ||
            (transform.position.y < 0 - maxHeight / 2) ||
            (transform.position.y > 0 + maxHeight / 2))
        {
            Destroy(gameObject);
        }

    }
}