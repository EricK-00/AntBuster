using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class AntGenerator : MonoBehaviour
{
    private const int ANT_COUNT = 6;

    private GameObject objCanvasGO;
    private RectTransform antCaveRect;

    private GameObject antPrefab;
    private List<GameObject> antList = new List<GameObject>();

    private void Awake()
    {
        objCanvasGO = Functions.GetRootGameObject(Functions.NAME_OBJCANVAS);
        antCaveRect = objCanvasGO.FindChildGameObject(Functions.NAME_ANTCAVE).GetComponent<RectTransform>();
        antPrefab = Functions.PREFAB_ANT;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respone(GameObject sender)
    {
        StartCoroutine(ResponeCoroutine(sender));
    }

    private IEnumerator Initialize()
    {
        for (int i = 0; i < ANT_COUNT; i++)
        {
            GameObject antInst = Instantiate(antPrefab, transform);
            antList.Add(antInst);
            antInst.name = $"Ant{i + 1}";
            antInst.GetComponent<RectTransform>().position = antCaveRect.position;
            antInst.SetActive(false);

        }

        TMP_Text startCounter = antCaveRect.GetChild(0).gameObject.GetComponent<TMP_Text>();
        for (int i = 5; i > 0; i--)
        {
            startCounter.text = i.ToSafeString();
            yield return new WaitForSeconds(1f);
        }
        startCounter.gameObject.SetActive(false);

        foreach (var antInst in antList)
        {
            antInst.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

    }

    private IEnumerator ResponeCoroutine(GameObject sender)
    {
        yield return new WaitForSeconds(1.5f);
        sender.transform.position = antCaveRect.position;
        sender.SetActive(true);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawCube(antCaveRect.position, new Vector3(1, 1, 1));
    //}
}