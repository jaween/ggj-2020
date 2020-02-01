using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public MovementController movementController;
    public HazardManager hazardManager;
    public BubbleController bubbleController;
    public EnemySpawner enemySpawner;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        movementController.enabled = false;
        hazardManager.enabled = false;
        enemySpawner.spawning = false;
        bubbleController.expanding = false;
        gameOverText.enabled = true;
    }
}
