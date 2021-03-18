using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float Variable", order = 1)]
public class FloatVariableSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float Value;

    public void SetValue(float value)
    {
        Value = value;
    }

    public void SetValue(FloatVariableSO value)
    {
        Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariableSO amount)
    {
        Value += amount.Value;
    }

    public void VariableInitialize()
    {
        Value = 0.0f;
    }
}