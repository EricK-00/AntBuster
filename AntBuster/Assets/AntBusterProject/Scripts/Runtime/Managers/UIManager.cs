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

    private GameObject uiCanvasGO;
    private TMP_Text desc;
    private GameObject gameOver;

    private TargetController targetController;

    private void Awake()
    {
        uiCanvasGO = Functions.GetRootGameObject(Functions.NAME_UICANVAS);
        desc = uiCanvasGO.FindChildGameObject(Functions.NAME_UI_DESC).GetComponent<TMP_Text>();
        gameOver = uiCanvasGO.FindChildGameObject(Functions.NAME_UI_GAMEOVER);

        targetController = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS).FindChildGameObject(Functions.NAME_TARGET).GetComponent<TargetController>();
    }

    public void PrintDesc(string str)
    {
        desc.text = str;
    }

    public void Target(GameObject target)
    {
        targetController.TargetObject(target);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
