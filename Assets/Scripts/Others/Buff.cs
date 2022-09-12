using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] int multiplier;
    [SerializeField] int duration;

    private void OnTriggerEnter(Collider other)
    {
        Shooter player = other.gameObject.GetComponent<Shooter>();
        if (player != null && player.CompareTag("Player"))
        {
            player.IncreaseAttackspeedForTime(multiplier, duration);
            Destroy(gameObject);
        }
    }
}
