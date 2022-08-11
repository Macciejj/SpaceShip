using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20;

    private ControlActions controlAction;

    private InputAction move;
    private InputAction fire;

    private Mover mover;
    private Shooter shooter;

    private void Awake()
    {
        controlAction = new ControlActions();
        move = controlAction.player.movement;
       // fire = controlAction.player.fire;
        mover = new Mover(transform, speed);
        shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {   
        move.Enable();
        //fire.Enable();
    }

    private void Update()
    {
        mover.Move(move.ReadValue<Vector2>());
        shooter.Fire(true);
        //shooter.Fire(fire.ReadValue<float>() > 0.1f);
    }

    private void OnDisable()
    {
        move.Disable();
        //fire.Disable();
    }
    
}
