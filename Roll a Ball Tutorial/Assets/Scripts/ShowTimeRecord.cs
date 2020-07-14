using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimeRecord : MonoBehaviour
{
    void Start()
    {
        string time = GameManager.instance.timeRecord.ToString("f2");
        GetComponent<Text>().text = $"Game Time\n{time}초";
    }
}
