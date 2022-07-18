using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }

}
