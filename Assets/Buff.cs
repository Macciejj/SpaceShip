using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] float attackSpeedMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        Shooter player = other.gameObject.GetComponent<Shooter>();
        if (player != null && player.CompareTag("Player"))
        {
            player.RateOfFire *= attackSpeedMultiplier;
            Destroy(gameObject);
        }
    }
}
