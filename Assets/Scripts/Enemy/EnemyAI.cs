using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Shooter shooter;
    private EnemyMover mover;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        mover = GetComponent<EnemyMover>();
    }

   private void Update()
    {
        Shoot();
        mover.Move();
    }

    private void Shoot()
    {
        currentPosition = transform.position;
        if (currentPosition == lastPosition)
        {
            if (shooter != null) shooter.Fire(true);
        }

        lastPosition = currentPosition;
    }
}
