using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 경과된 시간 누적하기
        GameObject.Find("StageTimer").GetComponent<StageTimer>().isClearStage = true;

        GameManager.instance.timeRecord += GameObject.Find("StageTimer").GetComponent<StageTimer>().t;

        // 현재 Scene 다시 시작하기
        GameManager.instance.RestartCurrentScene();
    }
}
