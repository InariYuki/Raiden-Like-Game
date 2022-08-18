using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[0];
    [SerializeField] float spawn_interval = 0.2f;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] float maxHP;
    [SerializeField] Image hpBar;
    [SerializeField] Text scoreDisplay;
    int totalScore = 0;
    float HP;
    private void Start()
    {
        AddScore(0);
        HP = maxHP;
        InvokeRepeating("Spawn" , spawn_interval , spawn_interval);
    }
    void Spawn()
    {
        Instantiate(enemies[Random.Range(0 , enemies.Length)] , transform.position + new Vector3(Random.Range(-2.4f , 2.4f) , 0 , 0) , transform.rotation);
    }
    public void TooglePauseMenu(bool isPause)
    {
        pauseMenu.SetActive(isPause ? true : false);
        Time.timeScale = isPause ? 0 : 1;
        FindObjectOfType<Player>().enabled = isPause ? false : true;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
    public void Hit(float damage)
    {
        HP -= damage;
        hpBar.fillAmount = HP / maxHP;
        if(HP <= 0)
        {
            //StaticVars.score = totalScore;
            if(PlayerPrefs.GetInt("highestScore") < totalScore)
            {
                PlayerPrefs.SetInt("highestScore", totalScore);
            }
            PlayerPrefs.SetInt("Score" , totalScore);
            SceneManager.LoadScene("GameOver");
        }
    }
    public void AddScore(int Score)
    {
        totalScore += Score;
        scoreDisplay.text = "Score : " + totalScore;
    }
}
