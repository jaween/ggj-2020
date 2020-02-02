using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraController : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, transform.up, rotationSpeed * Time.fixedDeltaTime);
    }
}
