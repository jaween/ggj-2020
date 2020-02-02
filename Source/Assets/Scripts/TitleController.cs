using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Button startButton;
    
    void Start()
    {
        startButton.Select();
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
