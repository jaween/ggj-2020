using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardIndicatorController : MonoBehaviour
{
    public Text timeText;
    
    void Start()
    {
        timeText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //timeText.text = ((int) (hazard.life / 10)).ToString();
    }
}
