using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
