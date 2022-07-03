using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed);
    }
}
