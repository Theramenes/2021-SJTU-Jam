﻿using UnityEngine;

[CreateAssetMenu(fileName = "Int Variable", menuName = "Variables/Int Variable", order = 2)]
public class IntVariableSO : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }

    public void SetValue(IntVariableSO value)
    {
        Value = value.Value;
    }

    public void ApplyChange(int amount)
    {
        Value += amount;
    }

    public void ApplyChange(IntVariableSO amount)
    {
        Value += amount.Value;
    }

    public void VariableInitialize()
    {
        Value = 0;
    }
}