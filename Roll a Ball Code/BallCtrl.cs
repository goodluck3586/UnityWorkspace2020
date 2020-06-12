using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCtrl : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    public AudioClip[] audioClips;
    public Text scoreText, winText;
    int score;
    int cubeTotalCount;

    private void Start()
    {
        score = 0;
        cubeTotalCount = GameObject.FindGameObjectsWithTag("Cube").Length;
        print($"cubeTotalCount: {cubeTotalCount}");
        SetScoreText();
    }

    // 키보드 방향키에의해 Ball이 움직이도록 코드를 만드시오.
    void Update()
    {
        // 1. 키보드 입력을 받아서 저장하고 콘솔에 출력한다.
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");  // -1 ~ +1
        //print($"h={h}, v={v}");

        // 2. Rigidbody 컴포넌트를 이용해서 키보드 입력 방향으로 움직이도록 한다.
        GetComponent<Rigidbody>().AddForce(new Vector3(h, 0f, v) * speed);
    }

    // 충돌 처리 메소드(충돌만 감지함)
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClips[Random.Range(0,3)]);  // 폭발음 재생
        Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);  // 특정한 오브젝트의 클론을 생성하는 메소드
        Destroy(other.gameObject);  // 충돌한 Cube 제거

        score++;
        SetScoreText();

        // 모든 큐브를 제거하면 화면에 "YOU WIN!!!"이라는 글자를 띄움.
        if (score == cubeTotalCount)
        {
            winText.text = "YOU WIN!!!";
            Invoke("LoadNextScene", 2f);  // 2초 후에 LoadNextScene() 실행
            // 게임 진행 시간 중지
            GameObject.Find("TimeCtrl").GetComponent<TimeCtrl>().isStageClear = true;
            GameManager.instance.timeRecord +=
                GameObject.Find("TimeCtrl").GetComponent<TimeCtrl>().gameTime;
        }
    }

    void SetScoreText()
    {
        scoreText.text = "SCORE : " + score + " / " + cubeTotalCount;
    }

    void LoadNextScene()
    {
        GameManager.instance.LoadNextScene();
    }

}

