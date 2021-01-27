using UnityEngine;

[CreateAssetMenu(fileName = "String Variable", menuName = "Variables/String Variable", order = 3)]
public class StringVariableSO : ScriptableObject
{
    [SerializeField]
    private string value = "";

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }
}