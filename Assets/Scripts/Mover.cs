using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 0.01f;
    public void Move(Vector3 direction)
    {
        transform.Translate(direction.x * speed, 0, direction.y * speed);
    }
}
