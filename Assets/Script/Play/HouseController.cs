using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField]private House[] houseList = new House[3];

    // Start is called before the first frame update
    void Start()
    {
        GameManger.Instance.houseController = this;
    }
}
