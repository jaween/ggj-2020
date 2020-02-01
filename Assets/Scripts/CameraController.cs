using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerNode;
    public float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerNode.position + playerNode.up * distance;
        transform.rotation = Quaternion.LookRotation(playerNode.forward, playerNode.up);
    }
}
