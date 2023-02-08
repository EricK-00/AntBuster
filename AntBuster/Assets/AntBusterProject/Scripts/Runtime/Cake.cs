using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{


    [SerializeField]
    private Sprite[] cakeSprites = new Sprite[GameManager.MAX_CAKE_COUNT + 1];

    private Image cakeImage;

    private void Awake()
    {
        cakeImage = GetComponent<Image>();
    }

    public void UpdateImage(int cakeImageCount)
    {
        if (GameManager.MAX_CAKE_COUNT - cakeImageCount >= 0)
        cakeImage.sprite = cakeSprites[GameManager.MAX_CAKE_COUNT - cakeImageCount];
    }
}