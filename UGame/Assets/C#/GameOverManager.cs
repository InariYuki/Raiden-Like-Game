using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    Text scoreDisplay;
    private void Awake()
    {
        scoreDisplay = transform.Find("ScoreTable").GetComponent<Text>();
    }
    private void Start()
    {
        //scoreDisplay.text = "だ计 : " + StaticVars.score + "\n" + "程蔼だ计 : ";
        scoreDisplay.text = "だ计 : " + PlayerPrefs.GetInt("Score") + "\n" + "程蔼だ计 : " + PlayerPrefs.GetInt("highestScore");
    }
}
