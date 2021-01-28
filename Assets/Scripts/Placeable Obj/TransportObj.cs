using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransportObj : MonoBehaviour
{
    public Vector3VariableSO TransportOffset;
    public UnityEvent OnBoyStartTransport;

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
        other.transform.position += TransportOffset.Value;

        OnBoyStartTransport.Invoke();
    }

}
