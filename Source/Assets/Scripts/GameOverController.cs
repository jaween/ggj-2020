﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public MovementController movementController;
    public HazardManager hazardManager;
    public BubbleController bubbleController;
    public CameraController cameraController;
    public EnemySpawner enemySpawner;
    public Text gameOverText;

    private float timeOfGameOver;
    private bool gameOver = false;

    public void GameOver()
    {
        if (!gameOver)
        {
            movementController.enabled = false;
            hazardManager.enabled = false;
            hazardManager.gameOver = true;
            enemySpawner.spawning = false;
            bubbleController.expanding = false;
            gameOverText.enabled = true;
            cameraController.gameOver = true;

            timeOfGameOver = Time.time;
            StartCoroutine(AnimateText());
            gameOver = true;
            StartCoroutine(Restart());
        }
    }

    IEnumerator AnimateText()
    {
        float timeSinceGameOver = Time.time - timeOfGameOver;
        float scale = 0.1f*Mathf.Sin(timeSinceGameOver) + 1f;
        gameOverText.transform.localScale = new Vector3(scale, scale, scale);
        yield return new WaitForEndOfFrame();
        StartCoroutine(AnimateText());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
