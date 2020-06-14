using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;
    public GameObject explosionPrefab;
    public AudioClip[] audioClips;
    public Text scoreText, winText;
    int score, totalCountOfCubes;

    void Start()
    {
        score = 0;
        totalCountOfCubes = GameObject.FindGameObjectsWithTag("PickUpCube").Length;
        print($"totalCountOfCubes : {totalCountOfCubes}");
        rb = GetComponent<Rigidbody>();
        scoreText.text = $"Score : {score}";
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // 키보드 왼쪽/오른쪽 화살표 입력값
        float v = Input.GetAxis("Vertical");    // 키보드 위/아래
        //print($"h = {h}, v = {v}");

        Vector3 movement = new Vector3(h, 0f, v);

        rb.AddForce(movement * speed);
    }

    // Collision 타입의 충돌을 처리하는 메소드
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "PickUpCube")
    //    {
    //        Destroy(collision.gameObject);  // 충돌된 오브젝트 제거
    //    }
    //}

    // Trigger 타입의 충돌을 처리하는 메소드
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpCube"))
        {
            Destroy(other.gameObject);  // 충돌된 오브젝트 제거
            // 폭발효과 Clone 객체를 생성하여 참조변수에 담기
            GameObject explosionObj = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(explosionObj.gameObject, 2.0f); // 2초 뒤에 폭발효과 Clone 제거

            // 폭발 사운드 재생
            GetComponent<AudioSource>().PlayOneShot(audioClips[Random.Range(0, 3)]);

            // ScoreText에 점수 표시
            score++;
            scoreText.text = $"Score : {score}";
            
            if(score == totalCountOfCubes)
            {
                winText.text = "You Win!!!";
            }
        }
    }


}
