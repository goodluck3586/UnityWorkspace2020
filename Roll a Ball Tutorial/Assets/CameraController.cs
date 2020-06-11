using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Player의 객체를 참조할 참조 변수 생성
    public GameObject player;
    Vector3 offset;

    void Start()
    {
        //player.GetComponent<Rigidbody>().AddForce(Vector3.right * 200f);
        print(player.transform.position);   // 볼의 위치
        print(transform.position);     // 카메라의 위치

        // 볼과 카메라의 초기 간격 측정
        offset = transform.position - player.transform.position;
        print($"볼과 카메라의 간격: {offset}");
    }

    void LateUpdate()
    {
        // 카메라의 위치를 볼의 위치 변화에 따라 수정(초기 간격만큼)
        this.transform.position = player.transform.position + offset;
    }
}
