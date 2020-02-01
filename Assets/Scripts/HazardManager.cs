﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{

    public GameObject[] hazardPrefabs;

    public GameObject hazardIndicatorPrefab;

    public Transform playerTransform;

    private IList<GameObject> hazards = new List<GameObject>();
    private IDictionary<GameObject, GameObject> hazardIndicators = new Dictionary<GameObject, GameObject>();
    public IList<GameObject> Hazards
    {
        get { return hazards; }
    }

    public BubbleController bubbleController;
    public ScoreController scoreController;

    public float indicatorDistance;
    void Start()
    {
        StartCoroutine(Generate());
    }

    private void Update()
    {
        for (var i = 0; i < hazards.Count; i++)
        {
            GameObject hazard = hazards[i];
            hazard.transform.position = hazard.transform.up * bubbleController.Radius;

            GameObject indicator;
            if (!hazardIndicators.TryGetValue(hazard, out indicator))
            {
                continue;
            }

            Vector3 playerToHazard = hazard.transform.position - playerTransform.position;
            float distanceToHazard = playerToHazard.magnitude;
            
            playerToHazard.Normalize();
            Vector3 playerToHazardProjOnPlayerUp = Vector3.Dot(playerToHazard, playerTransform.up) * playerTransform.up;
            Vector3 playerToHazardOnPlayerPlane = (playerToHazard - playerToHazardProjOnPlayerUp).normalized;

            indicator.transform.rotation = Quaternion.LookRotation(playerToHazardOnPlayerPlane, playerTransform.up);

            indicator.transform.position = playerTransform.position + playerToHazardOnPlayerPlane * indicatorDistance;
            /*if (distanceToHazard > 8) {
                indicator.transform.position = playerTransform.position + playerToHazardOnPlayerPlane * indicatorDistance;
            } else
            {
                indicator.transform.position = hazard.transform.position - playerToHazardOnPlayerPlane * indicatorDistance;
            }*/
            indicator.transform.position += indicator.transform.up * 2;
        }
    }

    IEnumerator Generate()
    {
        GenerateHazard();
        yield return new WaitForSeconds(5);
        StartCoroutine(Generate());
    }
    
    private void GenerateHazard()
    {
        Vector3 direction = Random.insideUnitSphere.normalized;
        int index = Random.Range(0, hazardPrefabs.Length);

        GameObject hazard = Instantiate(hazardPrefabs[index], direction * bubbleController.Radius, Quaternion.Euler(direction));
        hazard.transform.up = direction;
        hazards.Add(hazard);
        hazardIndicators[hazard] = Instantiate(hazardIndicatorPrefab);
    }

    public void DestroyHazard(GameObject hazard)
    {
        scoreController.HolesRepaired++;
        GameObject indicator = hazardIndicators[hazard];
        hazardIndicators.Remove(hazard);
        hazards.Remove(hazard);
        Destroy(indicator);
        Destroy(hazard);
    }
}