using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//needed for SceneManager.LoadScene(1);

public class MusicPlayer : MonoBehaviour
{
    private void Awake()//different Unity Lifecycle method that's called before Start
    {
        //lowercase g applies context to attached object
        DontDestroyOnLoad(gameObject);
    }



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
