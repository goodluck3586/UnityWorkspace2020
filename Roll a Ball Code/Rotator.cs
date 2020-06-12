using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 dir;

    void Start()
    {
        dir = new Vector3(Random.Range(-1.0f, 1.0f), 
            Random.Range(-1.0f, 1.0f), 
            Random.Range(-1.0f, 1.0f));
        //print($"랜덤 벡터 생성: {dir}");
    }

    void Update()
    {
        transform.Rotate(dir * 10f);
    }
}
