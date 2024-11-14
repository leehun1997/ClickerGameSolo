using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private static GameManger instance = null;
    public static GameManger Instance //게임 오브젝트를 만들지 않아도 알아서 생성되도록
    { 
        get 
        { 
        if(instance == null)
            {
                GameObject obj = new GameObject("GameManger");
                instance = obj.AddComponent<GameManger>();
                DontDestroyOnLoad(obj);
            }

            return instance; 
        } 
    }

    public Action clickEvent; //단일 데이터를 전달하는 것이 좋다

    public Clicker clicker;
    public ScoreManger scoreUI;
    public HouseController houseController;
    private float lastCheckTime;
    [SerializeField] private float checkDuration = 0.5f;

    public Queue<Action> clickEventQueue;
    public Action noneclickEventQueue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (clickEventQueue == null)//방어
        {
            clickEventQueue = new Queue<Action>();
        }
    }

    private void FixedUpdate()//아니며 다른 방법이 있는가?
    {
        if(Time.time - lastCheckTime < checkDuration)//매번 체크하는 것은 부하가 생길 것 같아서
        {
            return;
        }
        lastCheckTime = Time.time;

        if (clickEventQueue.Count > 0)
        {
            Debug.Log("ClickEventQueue active");
            clickEventQueue.Dequeue()?.Invoke();
            return;
        }

        //일반적으로 늘어나는 것이 아니라 누를때만 오르고 안누르면 값을 저장 했다가 한번에 수행
        Debug.Log("Not Clicking!");
        noneclickEventQueue?.Invoke();
        return;
    }
}
