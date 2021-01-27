using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragManager : MonoBehaviour
{
    public float sensitivityAmt = 1f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {

            Vector3 p0 = transform.position;
            Vector3 p01 = p0 - transform.right * Input.GetAxisRaw("Mouse X") * sensitivityAmt * Time.timeScale;
            Vector3 p03 = p01 - transform.up * Input.GetAxisRaw("Mouse Y") * sensitivityAmt * Time.timeScale;
            transform.position = p03;
        }
    }
}
