using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : MonoBehaviour
{
    int count = 1;
    Vector3 d = new Vector3(0f, 1f, 0f);
    

    Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(d * 1000f);
        print(transform.position);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // 왼쪽/오른쪽 화살표 입력(-1 ~ +1)
        float v = Input.GetAxis("Vertical"); // 위/아래 화살표 입력(-1 ~ +1)ㅠ
        Vector3 movement = new Vector3(h, 0f, v);
        print(movement);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("space"))
        {
            print($"스페이스바가 {count}번 눌렸습니다.");
            count++;
            rb.AddForce(0f, 50f, 0f);
        }
    }
}
