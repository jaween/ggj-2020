using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float life = 100;
    public float lifeReductionRate;

    void FixedUpdate()
    {
        life -= lifeReductionRate * Time.fixedDeltaTime;
        life = Mathf.Clamp(life, 0, 100);
    }
}
