using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContorller : MonoBehaviour
{


    Vector3 currPosition; //拖拽前的位置
    Vector3 newPosition; //拖拽后的位置
    private GameObject c;

    // Use this for initialization
    void Start()
    {
        c = GameObject.Find("Sub Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 开始拖拽 3D物体 拖拽是在平面拖拽 即 xy平面
    /// </summary>
    void OnMouseDrag()
    {
        //1：把物体的世界坐标转为屏幕坐标 (依然会        
        // currPosition = Camera.main.WorldToScreenPoint(transform.position);保留z坐标)

        //2：更新物体屏幕坐标系的x,y
        currPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, currPosition.z);

        //3：把屏幕坐标转为世界坐标
        newPosition = Camera.main.ScreenToWorldPoint(currPosition);

        //4：更新物体的世界坐标
        transform.position = newPosition;
    }

}
