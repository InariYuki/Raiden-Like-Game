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
        //scoreDisplay.text = "���� : " + StaticVars.score + "\n" + "�̰����� : ";
        scoreDisplay.text = "���� : " + PlayerPrefs.GetInt("Score") + "\n" + "�̰����� : " + PlayerPrefs.GetInt("highestScore");
    }
}
