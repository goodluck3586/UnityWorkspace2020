using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // 하나의 GameManager 인스턴스만 존재하도록 강제하는 로직
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadNextScene()
    {
        int currentSceneIndexNum = SceneManager.GetActiveScene().buildIndex;    // 인트로씬이라면 0
        SceneManager.LoadScene(currentSceneIndexNum + 1);
    }
}
