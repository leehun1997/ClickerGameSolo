using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    public ItemSO currentItemSO;

    public GameObject itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI price;
    public TextMeshProUGUI itemCount;

    public void SetSlot()
    {
        //itemImage = currentItemSO.ItemImage;
        itemImage.GetComponentInChildren<Image>().sprite = currentItemSO.ItemImage;
        itemName.text = currentItemSO.ItemName;
        price.text = (currentItemSO.ItemCost).ToString();
        itemCount.text = currentItemSO.ItemCount.ToString();
    }

    public void Onclick()
    {
        if (GameManger.Instance.scoreUI.BuyItem(currentItemSO.ItemCost))
        {
            currentItemSO.ItemCount++;
            SetSlot();
        }
    }
}
