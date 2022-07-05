using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] int health = 5;

    
    private void OnTriggerEnter(Collider other)
    {
        MissileMover missileMover = other.GetComponent<MissileMover>();
        if(missileMover != null)
        {
            TakeDamage(missileMover.GetDamage());
        }
    }

    private void TakeDamage(int damage)
    {
        if(health-damage <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }
    
}
