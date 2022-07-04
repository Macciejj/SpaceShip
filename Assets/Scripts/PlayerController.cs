using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] Transform missileSpawnPoint;
    [SerializeField] GameObject missile;
    [SerializeField] float speed = 0.01f;

    private ControlActions controlAction;
    private InputAction move;
    private InputAction fire;
    private Vector2 direction = Vector2.zero;
    private bool isFiring = false;
    private float nextShot = 0;
    
    
    private void Awake()
    {
        controlAction = new ControlActions();
        move = controlAction.player.movement;
        fire = controlAction.player.fire;
    }

    private void OnEnable()
    {       
        move.Enable();
        fire.Enable();
    }

    private void Update()
    {
        direction = move.ReadValue<Vector2>();
        direction.Normalize();
        Move();

        isFiring = fire.ReadValue<float>() > 0.1f;
        Fire();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    public void Move()
    {
        transform.Translate(direction.x * speed * Time.deltaTime, 0, direction.y * speed * Time.deltaTime);
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
