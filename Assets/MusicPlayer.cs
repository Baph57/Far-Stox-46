using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed for SceneManager.LoadScene(1);

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 10f);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
