using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraInOutController : MonoBehaviour
{
    public float inOutRateMultiplier;
    public float inOutDistanceMultiplier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.forward * Mathf.Sin(Time.time * inOutRateMultiplier) * inOutDistanceMultiplier;
    }
}
