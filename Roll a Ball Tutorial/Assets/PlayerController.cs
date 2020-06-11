using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // 키보드 왼쪽/오른쪽 화살표 입력값
        float v = Input.GetAxis("Vertical");    // 키보드 위/아래
        //print($"h = {h}, v = {v}");

        Vector3 movement = new Vector3(h, 0f, v);

        rb.AddForce(movement * speed);
    }
}
