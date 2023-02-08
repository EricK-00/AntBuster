using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetableObject : MonoBehaviour
{
    private string description;

    public void OnTarget()
    {
        //description = $"Level {level}\n\nEnerge: {currentEnerge}/{maxEnerge}\nSpeed: {speed * 10}inch/sec";
        UIManager.Instance.PrintDesc(description);
        UIManager.Instance.Target(gameObject);
    }
}