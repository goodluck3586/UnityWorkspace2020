using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;

    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        // public Material material 변수: Returns the first instantiated Material assigned to the renderer.
        // Material.mainTextureOffset 변수: public Vector2 mainTextureOffset ;
        // 왼쪽으로 이동하기 때문에 x축의 인자로 -값 전달
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(targetOffset, 0);
    }
}
