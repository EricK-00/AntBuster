using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Functions.GetRootGameObject(Functions.NAME_GAMEMANAGER).GetComponent<GameManager>();
            }
            return instance;
        }
    }

    public const int MAX_CAKE_COUNT = 8;

    public int Points { get; }
    public int Money { get; }
    public int Lv { get; } = 1;

    [SerializeField]
    private int cakeCount = MAX_CAKE_COUNT;
    [SerializeField]
    private int cakeImageCount = MAX_CAKE_COUNT;

    [SerializeField]
    private Sprite cursorSprite;
    private Texture2D cursorTexture;

    private GameObject objCanvasGO;
    private Cake cake;
    private GameObject board;
    private GameObject places;

    public float ObjCanvasWidth { get; private set; }
    public float ObjCanvasHeight { get; private set; }

    public bool TryCarryCake()
    {
        if (cakeImageCount <= 0)
            return false;

        --cakeImageCount;
        cake.UpdateImage(cakeImageCount);

        return true;
    }

    public void ReturnCake()
    {
        ++cakeImageCount;
        cake.UpdateImage(cakeImageCount);
    }

    public void EatCake()
    {
        --cakeCount;
        if (cakeCount <= 0)
        {
            GameOver();
        }
    }

    public void OnPlacingMode()
    {
        places.SetActive(true);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnTargetingMode()
    {
        places.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        Time.timeScale = 0f;
    }

    private void Awake()
    {
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        cake = objCanvasGO.FindChildGameObject(Functions.NAME_CAKE).GetComponent<Cake>();
        board = objCanvasGO.FindChildGameObject(Functions.NAME_BOARD);
        places = board.FindChildGameObject(Functions.NAME_PLACES);

        cursorTexture = cursorSprite.ConvertToTexture2D(FilterMode.Bilinear).SetPixelsAlpha(0.5f);

        ObjCanvasWidth = objCanvasGO.GetComponent<RectTransform>().rect.width;
        ObjCanvasHeight = objCanvasGO.GetComponent<RectTransform>().rect.height;
    }
}
