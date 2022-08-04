using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] ShipType shipType;
    public int health = 5;
    
     
    private void OnTriggerEnter(Collider other)
    {
        MissileMover missileMover = other.GetComponent<MissileMover>();
        if(missileMover != null)
        {
            if(shipType != missileMover.shipType)
            {
                TakeDamage(missileMover.GetDamage());
                Destroy(other.gameObject);
            }
            
        }
    }

    public ShipType GetShipType()
    {
        return shipType;
    }

    private void TakeDamage(int damage)
    {
        if(health-damage <= 0)
        {
            if(GetComponent<IKillable>()!=null)
            {
                GetComponent<IKillable>().Die();
            }           
        }
        else
        {
            health -= damage;
        }
    }
    
}
