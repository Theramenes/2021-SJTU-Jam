using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placeable Objects/Placeable Objects Info")]
public class PlaceableObjSO : ScriptableObject
{
    public StringVariableSO PlaceableObjName;
    public GameObject PlaceableObjPrefab;
    public Sprite PlaceableObjSprite;

}
