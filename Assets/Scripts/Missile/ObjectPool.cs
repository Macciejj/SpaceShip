using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Missile missilePrefab;
    private Queue<Missile> missiles = new Queue<Missile>();
    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Missile GetMissile()
    {
        if(missiles.Count == 0)
        {
            AddMissile();
        }
        return missiles.Dequeue();
    }

    private void AddMissile()
    {
        var missile = Instantiate(missilePrefab, transform);
        missile.gameObject.SetActive(false);
        missiles.Enqueue(missile);
    }

    public void ReturnToPool(Missile missile)
    {
        missile.gameObject.SetActive(false);
        missiles.Enqueue(missile);
    }


}
