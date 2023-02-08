using Mono.Cecil;
using Unity.VisualScripting;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UI;

interface ITargetable
{
    public string Description { get; }
    public void OnTarget();
}

public class Ant : MonoBehaviour, ITargetable
{
    public string Description { get; private set; }

    private GameObject objCanvasGO;

    private RectTransform antCaveRect;
    private RectTransform cakeRect;
    private Image EnergeImage;
    private GameObject antCake;

    private int level = 1;
    private int maxEnerge = 10;
    private int currentEnerge = 10;

    private float t = 0;

    private float speed = 0.12f;

    private bool isIncreased = true;

    private bool isCake = false;

    private void Awake()
    {
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        antCaveRect = objCanvasGO.FindChildGameObject(Functions.NAME_ANTCAVE).GetComponent<RectTransform>();
        cakeRect = objCanvasGO.FindChildGameObject(Functions.NAME_CAKE).GetComponent<RectTransform>();

        EnergeImage = gameObject.FindChildGameObject(Functions.NAME_ANT_HP).GetComponent<Image>();
        antCake = gameObject.FindChildGameObject(Functions.NAME_ANT_CAKE);
    }

    private void OnEnable()
    {
        Initialize();
    }

    void Update()
    {
        transform.position = Vector2.Lerp(antCaveRect.position, cakeRect.position, t);
        t += (isIncreased ? Time.deltaTime : -Time.deltaTime) * speed;

        if (t >= 1)
        {
            isIncreased = false;
            transform.LookAtVector2(antCaveRect.transform, Vector2.up);

            if (!isCake && GameManager.Instance.TryCarryCake())
            {
                antCake.SetActive(true);
                isCake = true;
                speed = 0.1f;
            }
        }
        else if (t <= 0)
        {
            if (isCake)
            {
                GameManager.Instance.EatCake();
            }
            Initialize();
        }
    }

    public void OnTarget()
    {
        Description = $"Level {level}\n\nEnerge: {currentEnerge}/{maxEnerge}\nSpeed: {speed * 10}inch/sec";
        UIManager.Instance.PrintDesc(Description);
        UIManager.Instance.Target(gameObject);
    }

    public void Damaged(int damage)
    {
        if (currentEnerge <= 0)
            return;

        currentEnerge -= damage;
        UpdateHPImage();
        if (currentEnerge <= 0)
        {
            if (isCake)
            {
                GameManager.Instance.ReturnCake();
            }

            currentEnerge = 0;
            speed = 0;
            antCake.SetActive(false);
            GetComponent<Animator>().SetTrigger("isDead");
        }
    }

    public void Die()
    {
        transform.parent.GetComponent<AntGenerator>().Respone(gameObject);
        gameObject.SetActive(false);
    }

    private void Initialize()
    {
        t = 0;
        isIncreased = true;
        transform.LookAtVector2(cakeRect.transform, Vector2.up);
        currentEnerge = maxEnerge;
        UpdateHPImage();
        speed = 0.12f;
        antCake.SetActive(false);
        isCake = false;
    }

    private void UpdateHPImage()
    {
        EnergeImage.fillAmount = (float)currentEnerge / maxEnerge;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Functions.TAG_BULLET)
        {
            Damaged(collision.gameObject.GetComponent<Bullet>().Power);
        }
    }
}