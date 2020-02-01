using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject[] hazardPrefabs;
    private IList<GameObject> hazards = new List<GameObject>();

    public float radius;
    void Start()
    {
        StartCoroutine(Generate());
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
        hazards.Add(hazard);
    }

    public void DestroyHazard(GameObject hazard)
    {
        hazards.Remove(hazard);
        Destroy(hazard);
    }
}
