using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 게임이 시작되면 큐브를 지정한 숫자만큼 랜덤한 위치에 생성 */
public class GenerateCubes : MonoBehaviour
{
    public int count;         // 1. 생성할 큐브의 개수 지정
    public GameObject cube;   // 2. 큐브 게임오브젝트 연결

    private void Awake()
    {
        // 3. 지정된 개수만큼 큐브를 랜덤한 위치에 생성
        for (int i = 0; i < count; i++)
        {
            // 랜덤한 위치의 Vector3
            Vector3 randomVec = new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f));

            // cube의 복제본을 생성 : Instantiate(클론 원본, 위치, 회전 상태)
            Instantiate(cube, randomVec, Quaternion.identity);
        }
    }

}
