using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookRotationController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 inputDir = new Vector3(horizontal, vertical, 0).normalized;
        transform.localRotation = Quaternion.Euler(inputDir.x, inputDir.y, 0);
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        transform.Rotate(Vector3.up, angle);
    }
}
