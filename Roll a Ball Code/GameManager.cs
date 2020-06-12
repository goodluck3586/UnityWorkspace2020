using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float timeRecord;

    private void Awake()
    {
        // 싱글톤 패턴(하나의 GameManager만 존재하도록 강제함.)
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);  // GameManager가 파괴되지 않도록 함.
    }

    // 다음 씬으로 전환하는 메소드
    public void LoadNextScene()
    {
        int currentSceneIndexNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndexNum + 1);
    }

    // 현재 씬 다시 시작
    public void RestartCurrentScene()
    {
        int currentSceneIndexNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndexNum);
    }

    // Stage01 씬부터 다시 시작
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene01");
    }
}
