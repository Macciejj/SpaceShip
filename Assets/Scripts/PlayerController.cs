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
    private Vector2 nextPosition = Vector2.zero;
    private bool isFiring = false;
    private float nextShot = 0;

    Vector2 minScreenBounds;
    Vector2 maxScreenBounds;



    private void Awake()
    {
        controlAction = new ControlActions();
        move = controlAction.player.movement;
        fire = controlAction.player.fire;
        
    }

    private void Start()
    {
        
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        print(minScreenBounds.x);
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        print(maxScreenBounds.x);
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
            //print(nextPosition.x + " " + maxScreenBounds.x);
            moveVector.x = 0;
        }
        if (nextPosition.y < minScreenBounds.y || nextPosition.y > maxScreenBounds.y)
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
