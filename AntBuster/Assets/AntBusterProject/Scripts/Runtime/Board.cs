using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject availablePlace;
    public GameObject blockedPlace;

    private RectTransform boardRect;
    private GameObject places;

    private const int MAX_ROW = 20;
    private const int MAX_COLUMN = 25;

    private int[,] initBoard = new int[MAX_ROW, MAX_COLUMN]
{
        { 1,1,1,1,1, 1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 1,1,1,1,1, 1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 1,1,1,1,1, 1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 1,1,1,1,1, 1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 1,1,1,1,1, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 1,1,1,1,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,1, 1,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,1,1, 1,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,1,1,1,1, 1,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,1,1,1,1, 1,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,1,1, 1,1,1,1,1 },
        { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,1,1, 1,1,1,1,1 },
};

    private void Awake()
    {
        boardRect = GetComponent<RectTransform>();
        places = boardRect.gameObject.FindChildGameObject(Functions.NAME_PLACES);

        Transform placeParent = places.transform;

        for (int i = 0; i < MAX_ROW; i++)
        {
            for (int j = 0; j < MAX_COLUMN; j++)
            {
                GameObject instance = (initBoard[i, j] == 0) ? Instantiate(availablePlace, placeParent) : Instantiate(blockedPlace, placeParent);
                instance.GetComponent<RectTransform>().localPosition = new Vector2(
                    (j + 0.5f) * boardRect.rect.width / MAX_COLUMN - boardRect.rect.width / 2,
                    boardRect.rect.height / 2 - (i + 0.5f) * boardRect.rect.height / MAX_ROW + boardRect.position.y);
            }
        }
    }
}