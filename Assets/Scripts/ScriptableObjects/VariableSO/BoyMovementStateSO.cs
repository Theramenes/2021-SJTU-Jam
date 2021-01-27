using UnityEngine;

[CreateAssetMenu]
public class BoyMovementStateSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    // the character velocity
    public Vector3VariableSO RBVelocity;

}
