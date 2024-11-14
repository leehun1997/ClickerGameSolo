using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;//인터페이스로 묶을 수 있나?
    [SerializeField] private TextMeshProUGUI passiveScoreText;
    [SerializeField] private TextMeshProUGUI unitText;

    public event Action OnUIChange;
    private float score = 0;
    private float showingScore;
    private float totalPassiveScore = 0;

    private void Awake()
    {
        GameManger.Instance.scoreUI = this;

        ChangeUI();

        OnUIChange += ChangeUI;//나중에 다른 효과를 넣을 수 있어서?
    }
    public void Changescore(float value)
    {
        score += value;
        OnUIChange?.Invoke();
    }
    public void ChangePassivescore(float value)
    {
        totalPassiveScore += value;
        OnUIChange?.Invoke();
    }
    public void AddPassivePoint()
    {
        score += totalPassiveScore;
        totalPassiveScore = 0;

        OnUIChange?.Invoke();
    }

    public void ChangeUI()//클리커 주변 정보 변경
    {
        unitText.text = CheckUnit();
        scoreText.text = showingScore.ToString();
        passiveScoreText.text = totalPassiveScore.ToString();
    }

    private string CheckUnit()
    {
        float temscore = score;
        int count = 0;

        while(temscore > 1000)
        {
            temscore = temscore / 1000;
            count++;
        }
        showingScore = float.Parse(temscore.ToString("N2"));

        if(count > 0)
        {
            return ((UnitEnum)count).ToString();
        }
        return "";
    }
}
