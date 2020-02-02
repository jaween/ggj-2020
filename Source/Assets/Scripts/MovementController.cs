using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed;
    public float friction;

    private Vector2 velocity = Vector2.zero;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        velocity *= friction;
        velocity = new Vector2(velocity.x + horizontal / 7, velocity.y + vertical / 7);
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

        transform.Rotate(Vector3.right, velocity.y);
        transform.Rotate(Vector3.forward, -1 * velocity.x);
    }
}
