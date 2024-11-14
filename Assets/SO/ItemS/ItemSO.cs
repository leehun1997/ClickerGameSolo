using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    //[SerializeField]
    public string ItemName;
    public Sprite ItemImage;
    public float ItemCost;
}
