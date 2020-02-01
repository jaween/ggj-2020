using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public HazardManager hazardManager;
    public BubbleController bubbleController;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = transform.up * bubbleController.Radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hazard>() != null)
        {
            hazardManager.DestroyHazard(other.gameObject);
        }
    }
}
