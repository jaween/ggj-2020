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
        //transform.localRotation = Quaternion.Euler(inputDir.x, inputDir.y, 0);
        float angle = Mathf.Atan2(horizontal, vertical);
        Vector3 targetForwardLocal = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        float currentAngle = Mathf.Acos(Vector3.Dot(transform.forward, targetForwardLocal));

        //Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
        //Vector3.RotateTowards(targetForwardLocal, transform.forward, 1 * Mathf.Deg2Rad, 1));
        //transform.Rotate(0, (angle - currentAngle)* Mathf.Rad2Deg, 0, Space.Self);
        Vector3 targetWorldForward = transform.TransformDirection(targetForwardLocal);
        Debug.DrawLine(transform.position, transform.position + targetWorldForward, Color.red);
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.blue);
        if (targetWorldForward.sqrMagnitude > 0) {
            //transform.rotation = Quaternion.LookRotation(targetWorldForward.normalized, transform.up);
        }
    }
}
