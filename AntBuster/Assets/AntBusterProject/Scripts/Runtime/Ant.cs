using Mono.Cecil;
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
    public string Description { get; private set; } = "Ant";

    private GameObject objCanvasGO;
    private Vector2 startPos;
    private RectTransform cakeRect;
    private Image EnergeImage;
    private GameObject antCake;

    private int level = 1;
    private int maxEnerge = 10;
    private int currentEnerge = 10;

    private float t = 0;

    public float speed = 0.12f;

    private bool isIncreased = true;

    private void Awake()
    {
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        cakeRect = objCanvasGO.FindChildGameObject(Functions.NAME_CAKE).GetComponent<RectTransform>();

        EnergeImage = gameObject.FindChildGameObject(Functions.NAME_ANT_HP).GetComponent<Image>();
        antCake = gameObject.FindChildGameObject(Functions.NAME_ANT_CAKE);
    }

    private void OnEnable()
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = GetComponent<RectTransform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(startPos, cakeRect.position, t);
        t += (isIncreased ? Time.deltaTime : -Time.deltaTime) * speed;

        if (t >= 1)
        {
            isIncreased = false;
            antCake.SetActive(true);
        }
        else if (t <= 0)
        {
            isIncreased = true;
            antCake.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Damaged(1);
        }
    }

    public void OnTarget()
    {
        Description = $"Level {level}\n\nEnerge: {currentEnerge}/{maxEnerge}\nSpeed: {speed * 10}inch/sec";
        UIManager.Instance.PrintDesc(Description);
        UIManager.Instance.Target(gameObject);
    }

    private void UpdateHPImage()
    {
        EnergeImage.fillAmount = (float)currentEnerge / maxEnerge;
    }

    public void Damaged(int damage)
    {
        if (currentEnerge <= 0)
            return;

        currentEnerge -= damage;
        UpdateHPImage();
        if (currentEnerge <= 0)
        {
            currentEnerge = 0;
            speed = 0;
            GetComponent<Animator>().SetTrigger("isDead");
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        transform.parent.GetComponent<AntGenerator>().Respone(gameObject);
    }

    private void Initialize()
    {
        t = 0;
        isIncreased = true;
        currentEnerge = maxEnerge;
        UpdateHPImage();
        speed = 0.12f;
    }
}