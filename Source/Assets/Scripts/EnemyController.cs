using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float randomDirectionRange;
    public BubbleController bubbleController;

    private float angleAcc = 0;
    private float angleVelocity = 0;
    private Vector2 directionInPlane = new Vector2(2, 1);

    float scale = 0;
    float maxScale;
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        maxScale = Random.Range(3, 5);
    }

    void FixedUpdate()
    {
        transform.position = transform.up * bubbleController.Radius;
        transform.Rotate(Vector3.right, directionInPlane.x * speed * Time.fixedDeltaTime);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 2, Color.blue);
        
        angleAcc += Random.Range(-randomDirectionRange / 2, randomDirectionRange / 2);
        angleAcc = Mathf.Clamp(angleAcc, -0.02f, 0.02f);
        angleVelocity += angleAcc;
        angleVelocity = Mathf.Clamp(angleVelocity, -1, 1);
        transform.Rotate(Vector3.up, angleVelocity);

        scale += Time.fixedDeltaTime * 5;
        scale = Mathf.Clamp(scale, 0, maxScale);
        transform.localScale = Vector3.one * scale;
    }
}
