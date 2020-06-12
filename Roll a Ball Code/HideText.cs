using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 스테이지 이름이 1초 후 사라지도록 하는 스크립트
public class HideText : MonoBehaviour
{
    
    void Start()
    {
        Invoke("HideStageName", 1f);  // 1초 후에 HideStageName() 실행
    }

    void HideStageName()
    {
        GetComponent<Text>().text = "";
    }
    
}
