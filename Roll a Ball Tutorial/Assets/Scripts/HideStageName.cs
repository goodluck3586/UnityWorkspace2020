using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideStageName : MonoBehaviour
{
    void Start()
    {
        Invoke("HideText", 1f);
    }

    void HideText()
    {
        GetComponent<Text>().text = "";
    }

}
