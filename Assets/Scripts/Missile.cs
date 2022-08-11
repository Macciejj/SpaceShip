using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;
    public Vector2 direction = Vector2.zero;

    public ShipType shipType;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction.x, 0, speed * Time.deltaTime * direction.y);
        if(IsOutOfScreen())
        {
            ObjectPool.Instance.ReturnToPool(this);
        }
    } 

    private bool IsOutOfScreen()
    {
        return (transform.position.x < ScreenBounds.MinScreenBounds.x ||
            transform.position.x > ScreenBounds.MaxScreenBounds.x ||
            transform.position.z < ScreenBounds.MinScreenBounds.z ||
            transform.position.z > ScreenBounds.MaxScreenBounds.z);
       
    }

    public int GetDamage()
    {
        return damage;
    }

}


