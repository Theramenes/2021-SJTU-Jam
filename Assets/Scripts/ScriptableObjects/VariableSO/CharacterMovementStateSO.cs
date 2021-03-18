using UnityEngine;

[CreateAssetMenu]
public class CharacterMovementStateSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    // the character velocity
    public Vector3VariableSO CharacterVelocity;
    public Vector3VariableSO CharacterPosition;

    public FloatVariableSO CharacterSpeed;
}
