using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Clicker : MonoBehaviour, Clickable
{
    [SerializeField] private CatSO currentSelectcatData;
    [SerializeField] private ItemSO[] itemList;
    [SerializeField] private GameObject catImage;
    [SerializeField] private TextMeshProUGUI catName;

    private event Action Click;
    private float stackPoint = 0f;
    private float lastClickTime;
    private bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManger.Instance.clicker = this;

        Click += ClickEvent;
        Click += ClickEventPassive;

        GameManger.Instance.noneclickEventQueue += NotClick;

        SetClicker();
    }

    public void OnClick()
    {
        clicked = true;
        lastClickTime = Time.time;

        GameManger.Instance.clickEventQueue.Enqueue(Click); // ���� �޴����� ���� ���ѳ��´�
    }

    public void NotClick()
    {
        if (!CheckReturn()) return;

        GameManger.Instance.scoreUI.ChangePassivescore(currentSelectcatData.CatPassivePoint);
    }

    public void ClickEvent()
    {
        Debug.Log("Click Event!");
        float value = 0f;

        if (itemList != null)
        {
            foreach (ItemSO item in itemList)
            {
                value += item.ItemCost;
            }
        }
        
        value += currentSelectcatData.CatClickPoint;

        Debug.Log(value);
        GameManger.Instance.scoreUI.Changescore(value);
    }

    public void ClickEventPassive()
    {
        Debug.Log("Click Event2!");

        GameManger.Instance.scoreUI.AddPassivePoint();
    }

    public void SetClicker()
    {
        catImage.GetComponentInChildren<Image>().sprite = currentSelectcatData.CatImage;
        catName.text = currentSelectcatData.CatName;
    }

    public void ChangeCurrentSelectData(CatSO catSO)
    {
        currentSelectcatData = catSO;
    }
    private bool CheckReturn()
    {
        if(!clicked) return true;

        if (Time.time - lastClickTime < currentSelectcatData.CatReturnTime) return false;

        clicked = false;
        return true;
    }
}
