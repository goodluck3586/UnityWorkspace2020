using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTimer : MonoBehaviour
{
    public Text timerText;
    public float limitTime;
    public float t;
    public bool isClearStage = false;


    void Update()
    {
        if (!isClearStage)
        {
            t = t + Time.deltaTime;   // 경과 시간 누적

            timerText.text = t.ToString("f2");  // 소수점 둘째 자리까지 출력

            if (t > limitTime)
            {
                GameManager.instance.RestartCurrentScene();
            }
        }
        
    }
}
