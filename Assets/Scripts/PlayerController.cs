using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] Transform missileSpawnPoint;
    [SerializeField] GameObject missile;
    [SerializeField] float speed = 20;
    
    private ControlActions controlAction;

    private InputAction move;
    private InputAction fire;

    private bool isFiring = false;
    private float nextShot = 0;

    private Mover mover;

    private void Awake()
    {
        controlAction = new ControlActions();
        move = controlAction.player.movement;
        fire = controlAction.player.fire;
        mover = new Mover(transform, speed);
    }

    private void OnEnable()
    {   
        move.Enable();
        fire.Enable();
    }

    private void Update()
    {
        mover.Move(move.ReadValue<Vector2>());
        isFiring = fire.ReadValue<float>() > 0.1f;
        Fire();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }
   
    private void Fire()
    {
        if(isFiring)
        {
            if (Time.time> nextShot)
            {
                if(rateOfFire!= 0) nextShot = Time.time + 1/rateOfFire;
                Instantiate(missile, missileSpawnPoint.position, Quaternion.identity);
            }
        }       
    }

   
}
