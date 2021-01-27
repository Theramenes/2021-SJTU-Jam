using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject subCamera;
    private GameObject v1;
    private GameObject v2;
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        v1 = GameObject.Find("S vcam1");
        v2 = GameObject.Find("L vcaml");
        subCamera.SetActive(false);
        v1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }

        if (mainCamera)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                v1.SetActive(true);
                //v2.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                v1.SetActive(false);
                //v2.SetActive(true);
            }
        }

    }
}
