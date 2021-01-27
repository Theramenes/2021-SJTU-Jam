using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSlot : MonoBehaviour
{
    public Image ItemSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void initialization()
    //{
    //    //itemSprite.GetComponent<Image>
    //}

    public void CreateSprite(Sprite spt) 
    {
        ItemSprite.sprite = spt;
    }
}
