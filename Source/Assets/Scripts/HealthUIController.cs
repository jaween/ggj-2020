using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    public ScoreController scoreController;
    private Text scoreText;
    void Start()
    {   
        scoreText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score\n" + scoreController.Score.ToString();
    }
}
