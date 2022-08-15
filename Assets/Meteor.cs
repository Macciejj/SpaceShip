using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] int damage = 3;
    private void OnTriggerEnter(Collider other)
    {
        Stats player = other.gameObject.GetComponent<Stats>();
        if (player != null && player.GetShipType() == ShipType.player)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
