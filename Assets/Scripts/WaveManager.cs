using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefabs;
    private UICountdown uICountdown;

    private void Awake()
    {
        uICountdown = FindObjectOfType<UICountdown>();
    }


    private void Update()
    {       
       if(uICountdown.IsCountdownFinished) SpawnWave();
    }

    private void SpawnWave()
    {      
        if (IsOnlyPlayerOnBoard())
        {
            int randomNumber = Random.Range(0, wavePrefabs.Length);
            Instantiate(wavePrefabs[randomNumber], transform);        
        }
    }

    private static bool IsOnlyPlayerOnBoard()
    {
        Stats[] stats = FindObjectsOfType<Stats>();
        return stats.Length == 1 && stats[0].GetShipType() == ShipType.player;
    }
}

