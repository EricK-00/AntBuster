using UnityEngine;
using UnityEngine.EventSystems;

public class CannonCreateButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject toolTip;

    private void Awake()
    {
        toolTip = gameObject.FindChildGameObject(Functions.NAME_CANNONTOOLTIP);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.OnTargetingMode();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.OnPlacingMode();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    }
}