using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public BubbleController bubbleController;
    public bool spawning = true;

    public int initialEnemyCount;
    public int secondsBetweenSpawns;
    
    void Start()
    {
        StartCoroutine(SpawnTask());
        for (int i = 0; i < initialEnemyCount; i++)
        {
            Spawn();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Vector3 direction = Random.onUnitSphere;
        GameObject enemy = Instantiate(enemyPrefab, direction * bubbleController.Radius, Quaternion.LookRotation(Random.onUnitSphere, transform.up), this.transform);
        enemy.GetComponent<EnemyController>().bubbleController = bubbleController;
    }

    IEnumerator SpawnTask()
    {
        yield return new WaitForSeconds(secondsBetweenSpawns);
        Spawn();

        if (spawning)
        {
            StartCoroutine(SpawnTask());
        }
    }
}
