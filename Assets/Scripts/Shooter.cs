using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] Transform missileSpawnPoint;
    [SerializeField] GameObject missile;

    private float nextShot = 0;

    public void Fire(bool isFiring)
    {
        if (isFiring)
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + rateOfFire;
                Instantiate(missile, missileSpawnPoint.position, Quaternion.identity);
            }
        }
    }
}
