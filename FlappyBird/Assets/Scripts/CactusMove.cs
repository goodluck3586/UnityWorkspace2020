using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMove : MonoBehaviour
{
    public float cactusSpeed;   // 선인장 장애물의 속도

    // Start() 함수보다 먼저 선언되는 메서드 객체를 초기화시키는 메서드
    private void OnEnable()
    {
        // 화면 오른쪽 밖에 위치하도록 함.
        this.transform.position = new Vector3(6f, Random.Range(-1, 1.5f), 1);
    }

    void Update()
    {
        transform.Translate(Vector3.left * cactusSpeed * Time.deltaTime);

        // 선인장이 x축 위치가 -6 보다 작아지면 제거
        if(this.transform.position.x < -6f)
            Destroy(this.gameObject);
    }
}
