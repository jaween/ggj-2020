using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int pointsPerHole;
    public int pointsPerBubbleSize;

    private int holesRepaired = 0;
    public int HolesRepaired
    {
        get { return holesRepaired; }
        set { holesRepaired = value; }
    }

    public int Score
    {
        get { return holesRepaired * pointsPerHole + (int) (bubbleSize * pointsPerBubbleSize); }
    }

    private float bubbleSize = 0;

    public BubbleController bubbleController;

    private void Update()
    {
        bubbleSize = bubbleController.Radius;
    }
}
