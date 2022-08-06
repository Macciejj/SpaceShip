using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Shooter shooter;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if(currentPosition == lastPosition)
        {
            shooter.Fire(true);
        }
        
        lastPosition = currentPosition;
    }
}
