using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log($"{transform.localPosition}");
    }
}