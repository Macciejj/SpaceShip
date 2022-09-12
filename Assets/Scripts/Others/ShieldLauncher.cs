using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLauncher : MonoBehaviour
{
    [SerializeField] Stats shieldOwner;
    void Update()
    {
        if(shieldOwner.hasShild)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!shieldOwner.hasShild)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
