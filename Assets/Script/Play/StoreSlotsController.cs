using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum StoreSelectType
{
    Cat,
    House,
    Consumable,
    Equipment
}

public class StoreSlotsController : MonoBehaviour
{
    private StoreController _controller;
    public StoreSelectType currentStoreSelectType;
    public ItemSO[] ItemSO;

    private void Start()
    {
        _controller = transform.parent.GetComponent<StoreController>();
    }

    public void SetStore()
    {
        SetSlotsType();
        SetSlots();
    }

    public void SetSlotsType()
    {
        switch (currentStoreSelectType)//switch문 말고 다른 방법?
        {
            case StoreSelectType.House:
                ItemSO = _controller.houseList;
                break;
            case StoreSelectType.Consumable:
                ItemSO = _controller.consumableList;
                break;
            case StoreSelectType.Equipment:
                ItemSO = _controller.equipmentList;
                break;
        }
    }

    public void SetSlots()
    {
        StoreSlot[] slots = GetComponentsInChildren<StoreSlot>();

        for(int i=0;i<ItemSO.Length; i++)
        {
            slots[i].currentItemSO = ItemSO[i];
            slots[i].SetSlot();
        }
    }
}