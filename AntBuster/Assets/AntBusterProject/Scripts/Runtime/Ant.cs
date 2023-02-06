using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private int level = 1;
    private int hp = 10;

    public RectTransform startRect;
    public RectTransform endRect;
    private float t = 0;

    private bool isIncreased = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(startRect.position, endRect.position, t);
        t += isIncreased ? Time.deltaTime * 0.25f : -Time.deltaTime * 0.25f;

        if (t >= 1)
        {
            isIncreased = false;
        }
        else if (t <= 0)
        {
            isIncreased = true;
        }
    }
}