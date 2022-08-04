using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefab;
    UICountdown uICountdown;

    private void Start()
    {
        uICountdown = FindObjectOfType<UICountdown>();
    }

    void Update()
    {       
       if(uICountdown.IsCountdownFinished) SpawnWave();
    }

    private void SpawnWave()
    {      
        if (IsOnlyPlayerOnBoard())
        {
            Instantiate(wavePrefab[Random.Range(0, wavePrefab.Length)], transform.position, Quaternion.identity);
        }
    }

    private static bool IsOnlyPlayerOnBoard()
    {
        Stats[] stats = FindObjectsOfType<Stats>();
        return stats.Length == 1 && stats[0].GetShipType() == ShipType.player;
    }
}

