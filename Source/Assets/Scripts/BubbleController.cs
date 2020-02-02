using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public bool expanding = true;
    public float radiusIncreaseRate;

    private float radius = 20;
    public float Radius
    {
        get { return radius; }
    }

    public HazardManager hazardManager;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (expanding)
        {
            radius += radiusIncreaseRate * Time.fixedDeltaTime;
        }

        transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }
}
