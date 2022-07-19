using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefab;
    GameObject currentWave;
    void Start()
    {
        
           // StartCoroutine(ExampleCoroutine());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FindObjectOfType<Stats>() == null)
        {
            Instantiate(wavePrefab[Random.Range(0, wavePrefab.Length)], transform.position, Quaternion.identity);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        
            if (FindObjectOfType<Stats>() == null)
            {
                Instantiate(wavePrefab[0], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(5);
            }

    }
    
}

