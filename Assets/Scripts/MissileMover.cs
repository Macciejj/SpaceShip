using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;
    [SerializeField] Vector2 direction = Vector2.up;
    public ShipType shipType;

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * direction.x, 0, speed * Time.deltaTime * direction.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }

}

public enum ShipType
{
    enemy = 1,
    player = 2
}


