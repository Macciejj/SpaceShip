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
    private Vector3 moveVector = Vector2.zero;
    private Vector3 nextPosition = Vector2.zero;
    private bool isFiring = false;
    private float nextShot = 0;

    Vector3 minScreenBounds;
    Vector3 maxScreenBounds;
    float cameraToPlayerDistance;

    [SerializeField] Camera camera;


    private void Awake()
    {
        
        controlAction = new ControlActions();
        move = controlAction.player.movement;
        fire = controlAction.player.fire;

        cameraToPlayerDistance = Vector3.Distance(transform.position, camera.transform.position);

        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cameraToPlayerDistance));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraToPlayerDistance));
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
        moveVector = new Vector3(direction.x * speed * Time.deltaTime, 0, direction.y * speed * Time.deltaTime);
        nextPosition = transform.position + moveVector;
        if (nextPosition.x < minScreenBounds.x || nextPosition.x > maxScreenBounds.x)
        {
            moveVector.x = 0;
        }
        if (nextPosition.z < minScreenBounds.z || nextPosition.z > maxScreenBounds.z)
        {
            moveVector.z = 0;
        }
        transform.Translate(moveVector);
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
