using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private GameObject objCanvas;
    private GameObject target;

    private void Awake()
    {
        objCanvas = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        target = objCanvas.FindChildGameObject(Functions.NAME_TARGET);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diffVector = (transform.position - target.transform.position).normalized;
        float cosTheta = Vector2.Dot(diffVector, Vector2.up);
        float angle = Vector2.Angle(diffVector, Vector2.right);

        transform.rotation = cosTheta >= 0 ? Quaternion.Euler(0, 0, angle) : Quaternion.Euler(0, 0, -angle);
    }
}
