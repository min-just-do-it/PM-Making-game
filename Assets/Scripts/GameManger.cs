//////////////////
//
///////////////
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    /// <summary> 초기화 </summary>
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    /// <summary> 재시작 </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restart");
    }

    /// <summary> 게임오버 </summary>
    public void GameOver()
    {
        Debug.Log("Game Over");
        // UI 띄우거나 씬 전환
    }
}
