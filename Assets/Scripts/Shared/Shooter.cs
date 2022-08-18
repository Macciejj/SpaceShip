using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    public float RateOfFire { get { return rateOfFire;  } set { rateOfFire = value; } }
    [SerializeField] List<Transform> missileSpawnPoints = new List<Transform>();
    [SerializeField] GameObject missile;

    private float nextShot = 0;

    public void Fire(bool isShooting)
    {
        if (isShooting)
        {
            if (Time.time > nextShot)
            {
                if (rateOfFire != 0) nextShot = Time.time + 1 / rateOfFire;
                foreach (var missileSpawnPoint in missileSpawnPoints)
                {
                    CreateMissile(missileSpawnPoint);
                }
                
            }
        }
    }

    private void CreateMissile(Transform missileSpawnPoint)
    {
        
        var missile = ObjectPool.Instance.GetMissile();
        missile.shipType = GetComponent<Stats>().GetShipType();
        missile.direction = missile.shipType == ShipType.player ? Vector2.up : Vector2.down;
        missile.gameObject.SetActive(true);
        missile.transform.position = missileSpawnPoint.position;
    }

    public void IncreaseAttackspeedForTime(int multiplier, int time)
    {
        StartCoroutine(IncreaseAttackspeedDelay(multiplier, time));
    }

    private IEnumerator IncreaseAttackspeedDelay(int multiplier,int seconds)
    {
        RateOfFire *= multiplier;
        yield return new WaitForSeconds(seconds);
        RateOfFire /= multiplier;
        yield return null;
    }

}
