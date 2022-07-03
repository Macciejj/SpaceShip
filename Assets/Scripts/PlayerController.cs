using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private ControlActions controlAction;
    private InputAction move;
    private InputAction fire;
    private Vector2 direction = Vector2.zero;
    private bool isFiring = false;

    private Mover mover;
    private Shooter shooter;
    
    
    private void Awake()
    {
        controlAction = new ControlActions();
        move = controlAction.player.movement;
        fire = controlAction.player.fire;
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {       
        move.Enable();
        fire.Enable();
    }

    private void FixedUpdate()
    {
        mover.Move(direction);
        shooter.Fire(isFiring);
    }

    private void Update()
    {
        direction = move.ReadValue<Vector2>();
        direction.Normalize();

        isFiring = fire.ReadValue<float>() > 0.1f;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    

   
}
