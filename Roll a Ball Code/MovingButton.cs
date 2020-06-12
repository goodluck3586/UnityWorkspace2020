using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButton : MonoBehaviour
{
    int direction = 1;

    void Update()
    {
        if (transform.position.y > 580)
            direction = -1;
        else if (transform.position.y < 400)
            direction = 1;
        transform.position = new Vector3(transform.position.x, transform.position.y + direction, transform.position.z);
    }
}
