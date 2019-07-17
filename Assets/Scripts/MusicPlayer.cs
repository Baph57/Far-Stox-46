using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()//different Unity Lifecycle method that's called before Start
    {
		int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; //theoretical array of music players

        if(numberOfMusicPlayers > 1)
		{
			Destroy(gameObject);
		}
		else
		{
        //lowercase g applies context to attached object
        DontDestroyOnLoad(gameObject);
		}
    }

}
