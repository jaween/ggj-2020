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
            Vector3 targetPos = (playerNode.position + playerNode.up * distance);
            Vector3 targetDir = (targetPos - transform.position).normalized;
            transform.position = targetPos;// Vector3.Lerp(transform.position, targetPos, 0.2f);
            //transform.rotation = Quaternion.LookRotation(playerNode.forward, playerNode.up);


            transform.rotation = Quaternion.LookRotation((playerNode.position - transform.position).normalized, playerNode.forward);


            //transform.rotation = Quaternion.LookRotation(playerNode.up, -targetDir);
            //transform.position = Vector3.Lerp(transform.position, playerNode.position + playerNode.up * distance, 0.01f);
            //transform.rotation = Quaternion.LookRotation(playerNode.forward, playerNode.up);
        }
    }
}
