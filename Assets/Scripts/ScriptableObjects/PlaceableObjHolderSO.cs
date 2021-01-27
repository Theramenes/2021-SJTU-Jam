using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placeable Objects/Placeable Objects List")]
public class PlaceableObjHolderSO : ScriptableObject
{
    public PlaceableObjSO[] PlaceableObjs;
}
