using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkyLimitTrigger : MonoBehaviour
{
    public UnityEvent BoyReachSkyLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BoyReachSkyLimit.Invoke();
        OnBoyTakeOff();
    }


    private void OnBoyTakeOff()
    {
        Debug.Log("Taking Off!!!");
    }
}
