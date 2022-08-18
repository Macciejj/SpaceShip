using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Stats player = other.gameObject.GetComponent<Stats>();
        if (player != null && player.CompareTag("Player"))
        {
            player.hasShild = true;
            Destroy(gameObject);
        }

    }
}
