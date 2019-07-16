using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI namespace, namespaces are collections of classes

public class ScoreBoard : MonoBehaviour
{


    int score; //by deafult ints intialize to zero
    Text scoreValue; //Text is available by using UE.UI

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = GetComponent<Text>();//reference to component on UI text
        scoreValue.text = score.ToString();
    }

    //public means that this function can call methods/funcs outside this class

    public void ScoreHandler(int amountToIncreaseScore)
    {
        score = score + amountToIncreaseScore;
        scoreValue.text = score.ToString();
    }
}
