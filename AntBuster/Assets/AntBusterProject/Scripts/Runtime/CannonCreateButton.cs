using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonCreateButton : MonoBehaviour, IPointerDownHandler
{
    private GameObject objCanvas;
    private GameObject board;
    private GameObject toolTip;

    public Sprite cursorSprite;

    private Texture2D cursorTexture;

    private void Awake()
    {
        objCanvas = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        board = objCanvas.FindChildGameObject(Functions.NAME_BOARD);
        toolTip = gameObject.FindChildGameObject(Functions.NAME_CANNONTOOLTIP);

        cursorTexture = cursorSprite.ConvertToTexture2D(FilterMode.Bilinear).SetPixelsAlpha(0.5f);

        Debug.Log($"readable? {cursorTexture.isReadable}, alphaIsTransparency? :{cursorTexture.alphaIsTransparency}, format? {cursorTexture.format}, mipmapCount? {cursorTexture.mipmapCount}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        board.SetActive(true);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnMouseOver()
    {
        toolTip.SetActive(true);
    }

    public void OnMouseExit()
    {
        toolTip.SetActive(false);
    }
}