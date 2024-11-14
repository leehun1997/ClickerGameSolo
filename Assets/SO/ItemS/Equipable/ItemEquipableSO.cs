using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/Item/Equipable")]
public class ItemEquipableSO : ItemSO
{
    //[SerializeField]
    public ItemEnum Tag;
    public StatsTypeEnum StatsTypeEnum;
    public float value;
}
