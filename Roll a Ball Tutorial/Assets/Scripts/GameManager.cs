using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float timeRecord;

    // 하나의 GameManager 인스턴스만 존재하도록 강제하는 로직
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // 다음 씬을 로드하는 메소드
    public void LoadNextScene()
    {
        int currentSceneIndexNum = SceneManager.GetActiveScene().buildIndex;    // 인트로씬이라면 0
        SceneManager.LoadScene(currentSceneIndexNum + 1);
    }

    // seconds 초 뒤에 LoadNextScene() 메소드 호출
    public void LoadNextSceneLateTime(float seconds)
    {
        Invoke("LoadNextScene", seconds);
    }

    // 현재 씬을 다시 시작
    public void RestartCurrentScene()
    {
        int currentSceneIndexNum = SceneManager.GetActiveScene().buildIndex;    // 인트로씬이라면 0
        SceneManager.LoadScene(currentSceneIndexNum);
    }
}
