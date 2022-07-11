using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] Transform missileSpawnPoint;
    [SerializeField] GameObject missile;

    private float nextShot = 0;

    public void Fire(bool isShooting)
    {
        if (isShooting)
        {
            if (Time.time > nextShot)
            {
                if (rateOfFire != 0) nextShot = Time.time + 1 / rateOfFire;
                Instantiate(missile, missileSpawnPoint.position, Quaternion.identity);
            }
        }
    }

}
