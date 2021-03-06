using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class TimerScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.timerText.color = Color.white;

        if(GameManagerScript.Instance.CurrentState == GameManagerScript.GameState.Playing)
        {
            GameManagerScript.Instance.LevelTime += Time.deltaTime;

            if (GameManagerScript.Instance.CalculateMedal() == GameManagerScript.Instance.gold)
            {
                UIManager.Instance.timerText.color = UIManager.Instance.gold;
            }
            else if (GameManagerScript.Instance.CalculateMedal() == GameManagerScript.Instance.silver)
            {
                UIManager.Instance.timerText.color = UIManager.Instance.silver;
            }
            else
            {
                UIManager.Instance.timerText.color = UIManager.Instance.bronze;
            }
        }

        UIManager.Instance.timerText.SetText(FormatTime(GameManagerScript.Instance.LevelTime));
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(100 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
