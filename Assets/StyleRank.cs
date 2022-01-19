using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class StyleRank : MonoBehaviour
{
    public Image UISprite, UIScore;
    public Text UIStreak;
    public GameObject ЧёрныйКонтур;
    public RectTransform UIScoreCanvas;
    public Sprite[] Sprite;
    public Color[] Color;
    public AudioSource[] AudioSources;
    public int Rank, Streak = 0;
    public float Score;
    private float ScorePosY, ScorePosHeight;

    public void Start()
    {
        RestartScore();
        ScorePosY = UIScoreCanvas.anchoredPosition.y/100;
        ScorePosHeight = UIScoreCanvas.sizeDelta.y/100;
    }

    public void SetScoreActive(bool active)
    {
        UISprite.gameObject.SetActive(active);
        UIScore.gameObject.SetActive(active);
        ЧёрныйКонтур.SetActive(active);
        UIStreak.gameObject.SetActive(active);
    }
    public void ChangeRank(int f)
    {
        Rank += f;
        if (Rank < 0)
            Rank = 0;
        if (Rank > Sprite.Length-1)
            Rank = Sprite.Length - 1;
            for(int i = 0; i <Sprite.Length; i ++)
                if (i <= Rank)
                    AudioSources[i].volume = 1;
                else AudioSources[i].volume = 0;
            
            UISprite.sprite = Sprite[Rank];
            UIScore.color = Color[Rank];
            UIStreak.color = Color[Rank]; 
    }


    public void ContinueStreak()
    {
        Streak++;
        if (Streak > 1)
        {
            UIStreak.gameObject.SetActive(true);
            UIStreak.text = "x" + Convert.ToString(Streak);
        }

        
    }
    public void ChangeScore(float i)
    {
        if (i > 0)
        {
            if (Streak==0)
            {
                if (i + Score > 100)
                {
                    ChangeRank(+1);
                    Score = i + Score -100;
                }
                else Score += i;
            }
            else
            {
                if (i * Streak + Score > 100)
                {
                    ChangeRank(+1);
                    Score = i * Streak + Score - 100;
                }
                else Score += i * Streak;
            }
        }
        else
        {
            i = i * -1;
            Streak = 0;
            UIStreak.gameObject.SetActive(false);
            if (i - Score > 0)
            {
                ChangeRank(-1);
                Score = 100 - i - Score;
            }
            else Score -= i;
        }
    }

    public void RestartScore()
    {
        Score = 0f;
        Rank = 0;
        Streak = 0;
        UIStreak.gameObject.SetActive(false);
        ChangeRank(0);
    }
    public void FixedUpdate()
    {
        if (Score>=0f)
        Score -= 0.2f;
        UIScoreCanvas.anchoredPosition = new Vector3(UIScoreCanvas.anchoredPosition.x, ScorePosY * Score, 0f);
        UIScoreCanvas.sizeDelta = new Vector3(UIScoreCanvas.sizeDelta.x, ScorePosHeight * Score, 0f);
        if (Score >= 100f)
        {
            if (Rank != Sprite.Length - 1)
            {
                ChangeRank(1);
                Score = 10f;
            }
            else Score = 100;
        }
        

        if (Score <= 0f && Rank > 0)
        {
            ChangeRank(-1);
            Score = 99f;
        }
    }
}
