using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsAndBuffsSpawner : MonoBehaviour
{

    [SerializeField] Probability[] prefabs;
    [SerializeField] int timeBetweenSpawns = 1;

    private List<Probability> prefabsWithWage = new List<Probability>();
    private Vector3 spawnPosition;

    private float nextSpawn = 0f;

    void Update()
    {
        DelaySpawn();
    }

    private Probability RandomIndex()
    {
        foreach (var item in prefabs)
        {
            for (int i = 0; i < item.GetComponent<Probability>().spawnProbability; i++)
            {
                prefabsWithWage.Add(item);
            }         
        }
        return prefabsWithWage[Random.Range(0,prefabsWithWage.Count)];
    }

    public void DelaySpawn()
    {
        if (Time.time > nextSpawn)
        {
            if (timeBetweenSpawns != 0) nextSpawn = Time.time + (1 / timeBetweenSpawns);
            int randomZPosition = Random.Range(-18, 17);           
            spawnPosition = new Vector3(randomZPosition, 0, ScreenBounds.MaxScreenBounds.z);

            Instantiate(RandomIndex(), spawnPosition, Quaternion.identity, transform);
        }
    }


}
