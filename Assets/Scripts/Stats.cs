using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MissileMover>()!=null)
        {
            Destroy(gameObject);
        }
    }
    
}
