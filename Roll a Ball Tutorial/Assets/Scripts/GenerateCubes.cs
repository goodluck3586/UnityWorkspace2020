using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 씬에 지정된 개수만큼 랜덤 위치에 큐브 생성
public class GenerateCubes : MonoBehaviour
{
    public int count;
    public GameObject Cube;

    void Awake()
    {
        for(int i=0; i<count; i++)
        {
            Instantiate(
                Cube,
                new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f)),
                Quaternion.identity
            );
        }
        
    }
}
