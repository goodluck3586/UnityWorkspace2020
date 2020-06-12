using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCtrl : MonoBehaviour
{
    public Text timeText;
    public float timeLimit;
    public float gameTime;
    public bool isStageClear = false;

    // 매 프레임마다 실행되는 함수
    void Update()
    {
        if (!isStageClear)
        {
            gameTime += Time.deltaTime;  // 한 프레임을 실행하는데 걸리는 시간
            timeText.text = gameTime.ToString("f2");  // 화면에 진행시간 표시
                                                      //timeText.text = $"{gameTime:f2}";

            // 제한시간을 초과한 경우
            if (gameTime > timeLimit)
            {
                GameManager.instance.timeRecord += gameTime;

                // 현재 스테이지 다시 재시작
                GameManager.instance.RestartCurrentScene();
            }
        }
    }
}
