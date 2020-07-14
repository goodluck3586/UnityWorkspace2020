using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpPower = 5f;
    public GameObject imageBird;
    public Vector3 lookDirection;
    public static Bird bird;
    Rigidbody rb;

    private void Awake()
    {
        bird = this;
        rb = GetComponent<Rigidbody>();
    }

    // 마우스 왼쪽 버튼 클릭에 따라 상하로 올라가는 동작과, y축의 속도에 따라 회전하는 동작 구현
    void Update()
    {
        // 게임이 종료되었는지 여부를 체크(end가 false인 경우만 점프 가능)
        if (GameManager.manager.end == false)    
        {
            // 마우스를 클릭한 경우 점프
            if (Input.GetMouseButtonDown(0) && this.transform.position.y < 4f)
            {
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(0, jumpPower, 0, ForceMode.VelocityChange);  // public void AddForce(float x, float y, float z, ForceMode mode = ForceMode.Force);
                GetComponent<AudioSource>().Play(); // Jump 사운드 재생
            }

            // 새의 이미지가 y축 속도에 따라 z축으로 회전하여 위로 올라갈때는 위를 아래로 내려갈때는 아래를 바라보도록 회전함.
            if(GameManager.manager.ready == false)
                lookDirection.z = rb.velocity.y * 10f + 20f;    // 새가 점프했을 경우 새의 lookDirection을 변화시켜 Y축으로 회전시켜주는 기능
        }

        // lookDirection의 Vector3값을 Quaternion으로 변환하여 회전시킴
        Quaternion R = Quaternion.Euler(lookDirection); // Vector3값을 Quaternion값으로 변환
        imageBird.transform.rotation = Quaternion.RotateTowards(imageBird.transform.rotation, R, 5f);   // public static Quaternion RotateTowards (Quaternion from, Quaternion to, float maxDegreesDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cactus")
        {
            rb.velocity = new Vector3(0, -3, 0);        // 아래로 떨어지기
            lookDirection = new Vector3(0, 0, -90f);    // 아래를 바라보도록 함.
            GameManager.manager.GameOver();             // GameOver() 메소드 실행
        }else if(other.tag == "Goal" && GameManager.manager.end != true)
        {
            GameManager.manager.GetScore();
        }
    }
}
