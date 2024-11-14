using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    private CatSO[] catList;
    private ItemHouseSO[] houseList;
    private ItemConsumableSO[] consumableList;
    private ItemEquipableSO[] equipableList;
    
    // Start is called before the first frame update
    void Start()
    {
        catList = Resources.LoadAll<CatSO>("SO/CatSO");
        houseList = Resources.LoadAll<ItemHouseSO>("SO/ItemSO/House");
        consumableList = Resources.LoadAll<ItemConsumableSO>("SO/ItemSO/Consumable");
        equipableList = Resources.LoadAll<ItemEquipableSO>("SO/ItemSO/Equipable");

        GetInfo<ItemHouseSO>(houseList);
    }

    private void GetInfo<T>(T[] list) where T : ItemSO
    {
        foreach (T item in list)
        {
            Debug.Log(item.name);
        }
    }
}
