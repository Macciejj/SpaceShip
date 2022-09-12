using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{

    [SerializeField] int Health = 1;

    private void OnTriggerEnter(Collider other)
    {
        Stats player = other.gameObject.GetComponent<Stats>();
        if (player != null && player.CompareTag("Player"))
        {
            player.IncreaseHealth(Health);
            Destroy(gameObject);
        }

    }
}
