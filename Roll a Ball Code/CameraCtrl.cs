using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ball의 위치를 파익하여 Camera가 따라다니도록 한다. */
public class CameraCtrl : MonoBehaviour
{
    // 1. Ball 게임 오브젝트 연결
    public GameObject ball;  // ball = GameObject.Find("Ball");
    Vector3 offset = new Vector3();

    // 2. Ball과 Camera의 유지 거리 측정
    void Start()
    {
        offset = this.transform.position - ball.transform.position;
        print(offset);
    }

    // 3. Ball이 움직이면 Camera가 따라 다닌다.
    void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }
}
