using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/Item/House")]
public class ItemHouseSO : ItemSO
{
    //[SerializeField]
    public ItemEnum Tag;
    public int houseLevel;
    public StatsTypeEnum StatType;
    public float value;
}