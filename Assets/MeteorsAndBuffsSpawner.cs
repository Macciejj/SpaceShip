using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsAndBuffsSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] prefabs;
    [SerializeField] int timeBetweenSpawns = 1;
    private Vector3 spawnPosition;

    private float nextSpawn = 0f;

    void Update()
    {
        DelaySpawn();
    }

    public void DelaySpawn()
    {
        if (Time.time > nextSpawn)
        {
            if (timeBetweenSpawns != 0) nextSpawn = Time.time + (1 / timeBetweenSpawns);
            int randomZPosition = Random.Range(-18, 17);           
            spawnPosition = new Vector3(randomZPosition, 0, ScreenBounds.MaxScreenBounds.z);
            int randomIndex = Random.Range(0, prefabs.Length - 1);
            Instantiate(prefabs[randomIndex], spawnPosition, Quaternion.identity, transform);
        }
    }


}
