using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerNode;
    public float distance;
    public bool gameOver = false;

    private Vector3 v;

    void Start()
    {
        v = playerNode.position + playerNode.up * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            transform.position = playerNode.position + playerNode.up * distance;
            transform.rotation = Quaternion.LookRotation(playerNode.forward, playerNode.up);


            //transform.rotation = Quaternion.LookRotation(playerNode.up, -targetDir);
            //transform.position = Vector3.Lerp(transform.position, playerNode.position + playerNode.up * distance, 0.01f);
            //transform.rotation = Quaternion.LookRotation(playerNode.forward, playerNode.up);
        }
    }
}
