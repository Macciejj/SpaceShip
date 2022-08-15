using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] ShipType shipType;
    public int health = 5;
    public bool hasShild = false;

    private void OnTriggerEnter(Collider other)
    {
        Missile missileMover = other.GetComponent<Missile>();
        if(missileMover != null)
        {
            if(shipType != missileMover.shipType)
            {
                TakeDamage(missileMover.GetDamage());
                ObjectPool.Instance.ReturnToPool(missileMover);
            }
            
        }
    }

    public ShipType GetShipType()
    {
        return shipType;
    }

    public void TakeDamage(int damage)
    {
        if(!hasShild)
        {
            if (health - damage <= 0)
            {
                if (GetComponent<IKillable>() != null)
                {
                    GetComponent<IKillable>().Die();
                }
            }
            else
            {
                health -= damage;
            }
        }
        hasShild = false;
       
    }
    
}