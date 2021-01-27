using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script
public class SpeedTextVariable : MonoBehaviour
{
    public Text UIText; // assign it from inspector
    public BoyMovementStateSO MovementState;

    void Start()
    {
        UIText.text = MovementState.RBSpeed.Value.ToString("f2");
    }

    private void Update()
    {
        UIText.text = MovementState.RBSpeed.Value.ToString("f2");
    }

    private void FixedUpdate()
    {
        
    }
}
