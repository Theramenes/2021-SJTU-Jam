using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarSlotDragCreate : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;

    public PlaceableObjSO PlaceableObjInfo;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag.");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 generatePosition = getCreatePosition();
        GameObject newPlaceableObject = Instantiate(PlaceableObjInfo.PlaceableObjPrefab, generatePosition, Quaternion.identity) as GameObject;

        this.gameObject.SetActive(false);
        Debug.Log("OnEndDrag.");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown.");
    }

    private Vector3 getCreatePosition()
    {
        float enter;
        Plane plane = new Plane(Vector3.back, Vector3.zero);
        Ray ray;
        Vector3 generatePosition = new Vector3();

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out enter))
        {
            generatePosition = ray.GetPoint(enter);
            Debug.Log("Generate Position:" + generatePosition);
        }

        return generatePosition;
    }

}
