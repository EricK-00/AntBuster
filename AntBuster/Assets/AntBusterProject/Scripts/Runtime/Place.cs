using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    private const string BLOCKED_NORMAL_HTML_RGB = "#FF1F00FF";
    private const string BLOCKED_HIGHLIGHTED_HTML_RGB = "#FFFFFFFF";

    private const string AVAILABLE_NORMAL_HTML_RGB = "#B5FF00FF";
    private const string AVAILABLE_HIGHLIGHTED_HTML_RGB = "#222222FF";

    private bool isAvailable = true;

    private Button placeButton;
    private GameObject objCanvasGO;
    private GameObject board;
    private GameObject cannonPrefab;

    private void Awake()
    {
        placeButton = GetComponent<Button>();
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        board = objCanvasGO.FindChildGameObject(Functions.NAME_BOARD);
        cannonPrefab = Functions.PREFAB_CANNON;
    }

    public void OnClick()
    {
        if (!isAvailable)
            return;

        GameObject cannonInst = Instantiate(cannonPrefab, board.transform);
        cannonInst.transform.position = transform.position;

        Color normalRGB;
        Color highlightedRGB;
        ColorUtility.TryParseHtmlString(BLOCKED_NORMAL_HTML_RGB, out normalRGB);
        ColorUtility.TryParseHtmlString(BLOCKED_HIGHLIGHTED_HTML_RGB, out highlightedRGB);

        ColorBlock newColors = placeButton.colors;
        newColors.normalColor = normalRGB;
        newColors.highlightedColor = highlightedRGB;
        placeButton.colors = newColors;

        GameManager.Instance.OnTargetingMode();

        //isAvailable = false;
    }
}