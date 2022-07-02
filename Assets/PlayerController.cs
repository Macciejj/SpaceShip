using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions inputAction;
    InputAction move;
    Vector2 direction = Vector2.zero;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }
    private void OnEnable()
    {
        move = inputAction.playercontrol.movement;
        move.Enable();

    }
    private void OnDisable()
    {
        move.Disable();
    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction.x * speed, transform.position.y, direction.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>();
    }
}
