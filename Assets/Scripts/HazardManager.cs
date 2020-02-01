using System.Collections;
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
        private set { }
    }

    public float radius;

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
            GameObject indicator;
            hazardIndicators.TryGetValue(hazard, out indicator);

            Vector3 playerToHazard = hazard.transform.position - playerTransform.position;
            float distanceToHazard = playerToHazard.magnitude;
            
            playerToHazard.Normalize();
            Vector3 playerToHazardProjOnPlayerUp = Vector3.Dot(playerToHazard, playerTransform.up) * playerTransform.up;
            Vector3 playerToHazardOnPlayerPlane = (playerToHazard - playerToHazardProjOnPlayerUp).normalized;

            indicator.transform.rotation = Quaternion.LookRotation(playerToHazardOnPlayerPlane, playerTransform.up);

            if (distanceToHazard > 8) {
                indicator.transform.position = playerTransform.position + playerToHazardOnPlayerPlane * indicatorDistance;
            } else
            {
                indicator.transform.position = hazard.transform.position - playerToHazardOnPlayerPlane * indicatorDistance;
            }
            indicator.transform.position += indicator.transform.up * 2;
        }
    }

    IEnumerator Generate()
    {
        GenerateHazard();
        yield return new WaitForSeconds(2);
        StartCoroutine(Generate());
    }

    private void GenerateHazard()
    {
        Vector3 direction = Random.insideUnitSphere.normalized;
        int index = Random.Range(0, hazardPrefabs.Length);

        GameObject hazard = Instantiate(hazardPrefabs[index], direction * radius, Quaternion.Euler(direction));
        hazardIndicators[hazard] = Instantiate(hazardIndicatorPrefab);
        hazards.Add(hazard);
    }

    public void DestroyHazard(GameObject hazard)
    {
        Destroy(hazardIndicators[hazard]);
        hazardIndicators.Remove(hazard);

        Destroy(hazard);
        hazards.Remove(hazard);
    }
}
