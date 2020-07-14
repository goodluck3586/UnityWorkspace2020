using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 게임 시작과 종료 이미지 변수
    public GameObject readyImage01;
    public GameObject readyImage02;
    public GameObject gameOverImage;
    public GameObject finalWindow;
    public GameObject imageNew;
    #endregion

    public static GameManager manager;
    public float waitingTime = 1.5f;    // 선인장 생성 간격
    public bool ready = true;           // 게임 준비 상태 여부 체크
    public bool end = false;            // 게임 종료 여부 체크
    public GameObject cactus;           // 장애물 오브젝트

    public AudioClip deathSound, goalSound;
    private AudioSource audio;

    public int score;
    public TextMesh socreText;
    public Text finalScoreText;
    public Text bestScoreText;

    void Start()
    {
        manager = this;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 누르면 게임시 시작되도로 한다., ready의 값으로 준비 상태인지 게임 상태인지 구분한다.
        // 게임이 시작되고 한 번만 실행됨.
        if(Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;  // 게임 준비 상태가 아님(게임 상태임)

            // public void InvokeRepeating (string methodName, float time, float repeatRate);
            InvokeRepeating("MakeCactus", 1f, waitingTime);  // 일정 시간마다 새로운 선인장 생성(MakeCacus 메소드를 일정 시간마다 호출)

            // 마우스 클릭이 발생하고 ready가 true일 때, UseGravity가 활성화 됨.
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;

            // UI 요소 감추기
            readyImage01.SetActive(false);
            readyImage02.SetActive(false);
        }
    }

    // 선인장 객체 생성
    public void MakeCactus()
    {
        Instantiate(cactus);   
    }

    public void GameOver()
    {
        if (end == true) return;

        end = true;                     // 게임 종료 여부 판단 변수값 true(Bird의 점프가 안됨)
        CancelInvoke("MakeCactus");     // MakeCactus() 메소드를 중지
        audio.PlayOneShot(deathSound);

        gameOverImage.SetActive(true);  // "Game Over" 이미지 보임
        // 점수판 위로 보이기
        finalWindow.SetActive(true);

        #region 현재 score가 best score이면 ImageNew를 Active 시킴.
        // PlayerPrefs : 게임 세션(session)사이에 플레이어 preference를 저장하고, preference에 접근하는 클래스
        if (score > PlayerPrefs.GetInt("BestScore"))    // Preference 파일에 존재하는 key에 대응하는 값 반환
        {
            PlayerPrefs.SetInt("BestScore", score);     // key로 식별된 Preference의 값 설정
            imageNew.SetActive(true);
        }
        else
        {
            imageNew.SetActive(false);
        }
        #endregion

        finalScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    internal void GetScore()
    {
        // Goal 지점을 통과하면 1점 플러스
        score += 1;
        socreText.text = score.ToString();

        audio.PlayOneShot(goalSound);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
