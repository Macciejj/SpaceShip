using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefab;

    void Update()
    {
        Stats[] stats = FindObjectsOfType<Stats>();
        if (stats.Length == 1 && stats[0].GetShipType() == ShipType.player)
        {
            Instantiate(wavePrefab[Random.Range(0, wavePrefab.Length)], transform.position, Quaternion.identity);
        }
    }   
}

