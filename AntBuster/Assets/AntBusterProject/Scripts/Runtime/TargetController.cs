using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public AnimationCurve curve;

    private GameObject ObjCanvas;
    private Image image;
    private Color color;
    private Color alphaZero;

    private UnityEvent antDie;

    private void Awake()
    {
        ObjCanvas = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);

        image = GetComponent<Image>();
        color = image.color;
        alphaZero = new Color(0, 0, 0, 0);
    }

    public IEnumerator TargetObject(GameObject target)
    {
        image.color = color;
        Vector2 startPos = transform.position;
        float t = 0f;

        while (Mathf.Abs(transform.position.x - target.transform.position.x) > 0.25f ||
            Mathf.Abs(transform.position.y - target.transform.position.y) > 0.25f)
        {
            transform.position = Vector2.Lerp(startPos, target.transform.position, curve.Evaluate(t));

            Debug.Log($"{transform.position} -> {target.transform.position}");

            t += 0.05f;
            yield return new WaitForSeconds(0.05f);

            if (target.activeInHierarchy == false)
            {
                transform.parent = ObjCanvas.transform;
                SetInvisible();
                yield break;
            }
        }

        transform.position = target.transform.position;
        transform.SetParent(target.transform);
    }

    private void SetInvisible()
    {
        image.color = alphaZero;
    }
}
