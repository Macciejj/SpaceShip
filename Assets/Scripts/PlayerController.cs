using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputAction;
    private InputAction move;
    private Vector2 direction = Vector2.zero;
    [SerializeField] float speed = 1f;

    private void Awake()
    {
        move = new PlayerInputActions().playercontrol.movement;
    }
    private void OnEnable()
    {       
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction.x * speed, 0, direction.y * speed);
    }

    private void Update()
    {
        direction = move.ReadValue<Vector2>();
        direction.Normalize();
    }
}
