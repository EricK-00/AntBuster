using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance 
    { 
        get {
            if (instance == null)
            {
                instance = Functions.GetRootGameObject(Functions.NAME_UIMANAGER).GetComponent<UIManager>();
            }
            return instance; } 
    }

    private GameObject uiCanvas;
    private TMP_Text desc;

    private TargetController targetController;

    private void Awake()
    {
        uiCanvas = Functions.GetRootGameObject(Functions.NAME_UICANVAS);
        desc = uiCanvas.FindChildGameObject(Functions.NAME_UI_DESC).GetComponent<TMP_Text>();

        targetController = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS).FindChildGameObject(Functions.NAME_TARGET).GetComponent<TargetController>();
    }

    public void PrintDesc(string str)
    {
        desc.text = str;
    }

    public void Target(GameObject target)
    {
        StartCoroutine(targetController.TargetObject(target));
    }
}
