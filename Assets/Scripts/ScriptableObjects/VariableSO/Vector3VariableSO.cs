using UnityEngine;

[CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Variables/Vector3 Variable", order = 4)]
public class Vector3VariableSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public Vector3 Value;

    public void SetValue(Vector3 value)
    {
        Value = value;
    }

    public void SetValue(Vector3VariableSO value)
    {
        Value = value.Value;
    }

    public void ApplyChange(Vector3 amount)
    {
        Value += amount;
    }

    public void ApplyChange(Vector3VariableSO amount)
    {
        Value += amount.Value;
    }
}
