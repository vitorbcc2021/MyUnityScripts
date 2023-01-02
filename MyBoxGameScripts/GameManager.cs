using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float yPosition;
    public int maxHazards;

    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1, maxHazards);

        for (int i = 0; i <= hazardToSpawn; i++)
        {
            float x = Random.Range(-4.8f, 4.8f);

            float dragHazard = Random.Range(1f, 2f);

            var hazard = Instantiate(hazardPrefab, new Vector3(x, yPosition, -1.3f), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = dragHazard;
        }

        yield return new WaitForSeconds(1f);

        yield return SpawnHazards();
    }
    
}