using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject availablePlace;
    public GameObject blockedPlace;

    public RectTransform standardRect;
    public GameObject goParent;

    int[,] board = new int[20, 25]
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
        for (int i  = 0; i < 20; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                GameObject instance = (board[i, j] == 0) ? Instantiate(availablePlace, goParent.transform) : Instantiate(blockedPlace, goParent.transform);
                instance.GetComponent<RectTransform>().localPosition = new Vector2(
                     (j + 0.5f) * standardRect.rect.width / 25 - standardRect.rect.width / 2,
                    standardRect.rect.height / 2 - (i + 0.5f) * standardRect.rect.height / 20 + standardRect.localPosition.y);
            }
        }
    }
}
