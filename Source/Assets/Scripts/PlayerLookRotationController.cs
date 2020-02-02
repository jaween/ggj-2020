using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookRotationController : MonoBehaviour
{
    Vector3 oldEulerAngles = Vector3.up;
    float bobbing = 0;
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
        Vector3 targetWorldForward = transform.TransformDirection(targetForwardLocal);
        Debug.DrawLine(transform.position, transform.position + targetWorldForward, Color.red);
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.blue);
        if (inputDir.sqrMagnitude > 0.2) {
            oldEulerAngles = new Vector3(Mathf.Abs(vertical + horizontal) * 35, angle * Mathf.Rad2Deg, 0);
        }
        transform.localEulerAngles = oldEulerAngles;
        transform.localPosition = Vector3.up * Mathf.Sin(bobbing) * 0.3f + Vector3.right * Mathf.Sin(bobbing / 2) * 0.1f;
        bobbing += Time.deltaTime * 50 * inputDir.magnitude;
    }
}
