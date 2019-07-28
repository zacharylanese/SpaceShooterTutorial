﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text wintext;
    public Text gamebytext;
    private bool gameOver;
    private bool restart;
    private int score;
    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        wintext.text = "";
        gamebytext.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.X))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
            GameObject hazard = hazards[Random.Range (0, hazards.Length)];
            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate (hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'X' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            wintext.text = "You Win!";
            gamebytext.text = "Game Created By Zachary Lanese";
            gameOver = true;
            restart = true;
        }
    }
    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gamebytext.text = "Game Created By Zachary Lanese";
        gameOver = true;
    }
}
