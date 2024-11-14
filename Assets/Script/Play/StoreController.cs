using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreController : MonoBehaviour
{
    public CatSO[] catList;
    public ItemHouseSO[] houseList;
    public ItemConsumableSO[] consumableList;
    public ItemEquipableSO[] equipmentList;

    public StoreSlotsController slots;
    
    // Start is called before the first frame update
    void Start()
    {
        catList = Resources.LoadAll<CatSO>("SO/CatSO");
        houseList = Resources.LoadAll<ItemHouseSO>("SO/ItemSO/House");
        consumableList = Resources.LoadAll<ItemConsumableSO>("SO/ItemSO/Consumable");
        equipmentList = Resources.LoadAll<ItemEquipableSO>("SO/ItemSO/Equipable");

        //GetInfo<ItemHouseSO>(houseList);
    }

    public T[] GetInfo<T>(T[] list) where T : ItemSO
    {
        return list;
    }

    public void OnStoreTypeButtonClick()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        foreach(StoreSelectType type in Enum.GetValues(typeof(StoreSelectType)))
        {
            Debug.Log($"{type.ToString()} {buttonName}");
            if (type.ToString() == buttonName)
            {
                slots.currentStoreSelectType = type;
                slots.SetStore();
                return;
            }
            continue;
        }
    }
}
