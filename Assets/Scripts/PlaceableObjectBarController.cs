using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceableObjectBarController : MonoBehaviour
{
    public PlaceableObjHolderSO Items;
    public GameObject BarSlotPrefab;

    public float SlotOffset;
    public float SlotStartPositionX;
    public float SlotStartPositionY;
    
    private 

    // Start is called before the first frame update
    void Start()
    {
        initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initialization() 
    {
        int size = Items.PlaceableObjs.Length;
        float barSlotWidth = BarSlotPrefab.GetComponent<Image>().rectTransform.sizeDelta.x;

        if (size == 0) return;

        for (int i = 0; i < size; i++)
        {
            GameObject childBarSlot = Instantiate(BarSlotPrefab, new Vector3(SlotStartPositionX + i * (SlotOffset + barSlotWidth), SlotStartPositionY, 0), Quaternion.identity) as GameObject;
            childBarSlot.transform.SetParent(this.transform);

            childBarSlot.GetComponent<BarSlot>().CreateSprite(Items.PlaceableObjs[i].PlaceableObjSprite);
            childBarSlot.GetComponentInChildren<BarSlotDragCreate>().PlaceableObjInfo = Items.PlaceableObjs[i];
        }
    }
}
