using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerLegacy : MonoBehaviour
{
    private Vector3 positionVector;
    private Vector3 oldUp;
    private Vector3 oldRight;
    private Vector3 oldForward;

    public float distance;
    public float maxSpeed;

    void Start()
    {
        positionVector = new Vector3(0, 0, distance);
        oldUp = new Vector3(transform.up.x, transform.up.y, transform.up.z);
        oldRight = new Vector3(transform.right.x, transform.right.y, transform.right.z);
        oldForward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        positionVector = Quaternion.AngleAxis(horizontal * maxSpeed, transform.forward) * Quaternion.AngleAxis(vertical * maxSpeed, transform.right) * positionVector;
        positionVector = Quaternion.AngleAxis(vertical * maxSpeed, transform.right) * positionVector;

        Vector3 newUp = positionVector.normalized;


        // FORWARD VECTOR
        // Finds the projection of new Up onto old right
        Vector3 projNewUpOnOldRight = Vector3.Dot(newUp, oldRight) * oldRight;

        // Projection of new Up onto plane created by old up and old forward
        Vector3 projNewUpOnOldUpForwardPlane = newUp - projNewUpOnOldRight;

        // Amount rotated by new Up from old Up in the old Up old Forward plane
        float diffAngleOldUpToNewUpInOldUpOldForwardPlane = Mathf.Acos(Vector3.Dot(oldUp, projNewUpOnOldUpForwardPlane)) * Mathf.Sign(vertical);
        if (float.IsNaN(diffAngleOldUpToNewUpInOldUpOldForwardPlane))
        {
            diffAngleOldUpToNewUpInOldUpOldForwardPlane = 0;
        }

        float diffAngleOldUpToNewUpInOldUpOldForwardPlaneDegs = diffAngleOldUpToNewUpInOldUpOldForwardPlane * Mathf.Rad2Deg;
        //transform.up = Quaternion.AngleAxis(diffAngleOldUpToNewUpInOldUpOldForwardPlaneDegs, oldRight) * transform.up;




        // RIGHT VECTOR
        // Finds the projection of new Up onto old forward
        Vector3 projNewUpOnOldForward = Vector3.Dot(newUp, oldForward) * oldForward;
        Debug.Log("new up is " + newUp + " projceting is " + Vector3.Dot(newUp, oldForward) + ", old forward" + oldForward);

        // Projection of new Up onto plane created by old up and old right
        Vector3 projNewUpOnOldUpRightPlane = newUp - projNewUpOnOldForward;

        // Amount rotated by new Up from old Up in the old Up old Forward plane
        float diffAngleOldUpToNewUpInOldUpOldRightPlane = Mathf.Acos(Vector3.Dot(oldUp, projNewUpOnOldUpRightPlane));
        Debug.Log("Diff ANgle is " + diffAngleOldUpToNewUpInOldUpOldRightPlane * Mathf.Rad2Deg);
        if (float.IsNaN(diffAngleOldUpToNewUpInOldUpOldRightPlane))
        {
            diffAngleOldUpToNewUpInOldUpOldRightPlane = 0;
        }

        float diffAngleOldUpToNewUpInOldUpOldRightPlaneDegs = diffAngleOldUpToNewUpInOldUpOldRightPlane * Mathf.Rad2Deg;
        Debug.Log("Diff ANgle is " + diffAngleOldUpToNewUpInOldUpOldRightPlaneDegs);
        //transform.right = Quaternion.AngleAxis(diffAngleOldUpToNewUpInOldUpOldRightPlaneDegs, oldForward) * transform.right;

        //transform.localPosition = positionVector;

        oldUp = newUp;
        oldRight = new Vector3(transform.right.x, transform.right.y, transform.right.z);
        oldForward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
        Debug.Log("old forward is " + oldForward);


    }
}
