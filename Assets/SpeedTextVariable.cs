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
<<<<<<< Updated upstream
        UIText.text = MovementState.RBSpeed.Value.ToString("f2");
=======
        UIText.text = MovementState.CharacterSpeed.Value.ToString("f1");
>>>>>>> Stashed changes
    }

    private void Update()
    {
<<<<<<< Updated upstream
        UIText.text = MovementState.RBSpeed.Value.ToString("f2");
=======
        UIText.text = MovementState.CharacterSpeed.Value.ToString("f1");
>>>>>>> Stashed changes
    }

    private void FixedUpdate()
    {
        
    }
}
