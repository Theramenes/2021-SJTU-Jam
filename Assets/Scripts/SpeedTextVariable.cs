using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script
public class SpeedTextVariable : MonoBehaviour
{
    public Text UIText; // assign it from inspector
    public CharacterMovementStateSO MovementState;

    void Start()
    {
        UIText.text = MovementState.CharacterSpeed.Value.ToString("f1");
    }

    private void Update()
    {
        UIText.text = MovementState.CharacterSpeed.Value.ToString("f1");
    }

    private void FixedUpdate()
    {
        
    }
}
