using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefabs;
    [SerializeField] List<GameObject> waves = new List<GameObject>();
    private UICountdown uICountdown;

    private void Awake()
    {
        foreach (var item in wavePrefabs)
        {
            waves.Add(Instantiate(item, transform.position, Quaternion.identity));
        }
        foreach (var item in waves)
        {
            item.SetActive(false);
        }
        
    }

    private void Start()
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
            waves[randomNumber].SetActive(true);           
        }
    }

    private static bool IsOnlyPlayerOnBoard()
    {
        Stats[] stats = FindObjectsOfType<Stats>();
        return stats.Length == 1 && stats[0].GetShipType() == ShipType.player;
    }
}

