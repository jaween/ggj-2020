using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float healthReductionMultiplier;
    private float health = 100;

    public float Health
    {
        get { return health; }
        private set { }
    }

    public HazardManager hazardManager;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        health -= hazardManager.Hazards.Count * Time.fixedDeltaTime * healthReductionMultiplier;
    }
}
