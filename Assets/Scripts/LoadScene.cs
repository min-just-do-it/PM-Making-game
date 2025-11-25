using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//시네마
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroUI");
        else if (Input.GetKeyDown(KeyCode.Keypad1))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Plan");
        else if (Input.GetKeyDown(KeyCode.Keypad2))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Underground");
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Plant");
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        else if (Input.GetKeyDown(KeyCode.Keypad5))
            UnityEngine.SceneManagement.SceneManager.LoadScene("TheEND");
    }
}
