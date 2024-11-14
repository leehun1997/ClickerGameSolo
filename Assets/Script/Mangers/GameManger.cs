using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private static GameManger instance = null;
    public static GameManger Instance //���� ������Ʈ�� ������ �ʾƵ� �˾Ƽ� �����ǵ���
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

    public Action clickEvent; //���� �����͸� �����ϴ� ���� ����

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

        if (clickEventQueue == null)//���
        {
            clickEventQueue = new Queue<Action>();
        }
    }

    private void FixedUpdate()//�ƴϸ� �ٸ� ����� �ִ°�?
    {
        if(Time.time - lastCheckTime < checkDuration)//�Ź� üũ�ϴ� ���� ���ϰ� ���� �� ���Ƽ�
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

        //�Ϲ������� �þ�� ���� �ƴ϶� �������� ������ �ȴ����� ���� ���� �ߴٰ� �ѹ��� ����
        Debug.Log("Not Clicking!");
        noneclickEventQueue?.Invoke();
        return;
    }
}
