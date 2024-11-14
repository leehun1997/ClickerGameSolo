using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/Item/Consumable")]
public class ItemConsumableSO : ItemSO
{
    //[SerializeField]
    public ItemEnum Tag;
    public StatsTypeEnum StatType;
    public float value;
}
