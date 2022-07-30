using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;
    [SerializeField] Vector2 direction = Vector2.up;

    public ShipType shipType;

    private void Start()
    {
        Player player = FindObjectOfType<Player>();

        if(shipType == ShipType.enemy && player != null)
        {
            Vector3 direction3D = player.transform.position - transform.position;
            direction = new Vector2(direction3D.x, direction3D.z);
            direction.Normalize();
        }
    }

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


