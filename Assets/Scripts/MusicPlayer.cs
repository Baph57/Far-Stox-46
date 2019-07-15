using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()//different Unity Lifecycle method that's called before Start
    {
        //lowercase g applies context to attached object
        DontDestroyOnLoad(gameObject);
    }

}
