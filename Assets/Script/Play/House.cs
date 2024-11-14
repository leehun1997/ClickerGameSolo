using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    [SerializeField] private ItemHouseSO ItemHouseSO;
    [SerializeField] private CatSO catSO;

    [SerializeField] private GameObject HouseImage;
    public bool isBuy = false;

    private void Start()
    {
        //SetHouse();
    }

    public void OnHouseClick()
    {
        if (ItemHouseSO == null) return;
        if (catSO == null) return;

        GameManger.Instance.clicker.ChangeCurrentSelectData(catSO);
        GameManger.Instance.clicker.SetClicker();
    }

    public void SetHouse()
    {
        if (ItemHouseSO == null) { return; }
        HouseImage.GetComponentInChildren<Image>().sprite = ItemHouseSO.ItemImage;
    }
}
