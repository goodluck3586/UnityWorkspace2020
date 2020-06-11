using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cube를 회전시키는 스크립트
public class Rotator : MonoBehaviour
{
    float rotateSpeed, x, y, z;

    void Start()
    {
        print("Time.deltaTime : " + Time.deltaTime);
        x = Random.Range(10f, 30f);
        y = Random.Range(10f, 30f);
        z = Random.Range(10f, 30f);
        rotateSpeed = Random.Range(5f, 10f);
    }

    void Update()
    {
        Quaternion qt = transform.rotation;
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime * rotateSpeed);   // new Vector3(0f, 1f, 0f);
    }
}
