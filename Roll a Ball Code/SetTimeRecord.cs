using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeRecord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float timeRecord = GameManager.instance.timeRecord;
        GetComponent<Text>().text = $"Time Record : {timeRecord:f2}초";
    }
}
