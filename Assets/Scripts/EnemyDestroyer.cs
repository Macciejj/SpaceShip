using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour, IKillable
{
    [SerializeField] int pointsForPlayerWhenDie = 1;
    private UIScoreManager uIScoreManager;

    private void Awake()
    {
        uIScoreManager = FindObjectOfType<UIScoreManager>();
    }

    public void Die()
    {
        uIScoreManager.Score += pointsForPlayerWhenDie;
        Destroy(gameObject);
    }

}
