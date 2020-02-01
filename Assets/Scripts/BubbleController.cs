using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float radiusIncreaseRate;

    private float radius = 20;
    public float Radius
    {
        get { return radius; }
    }

    public float healthReductionMultiplier;
    private float health = 100;

    public float Health
    {
        get { return health; }
    }

    public HazardManager hazardManager;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        health -= hazardManager.Hazards.Count * Time.fixedDeltaTime * healthReductionMultiplier;
        radius += radiusIncreaseRate * Time.fixedDeltaTime;

        transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }
}
