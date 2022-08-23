using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour, IKillable
{
    [SerializeField] int pointsForPlayerWhenDie = 1;
    private UIScoreManager uIScoreManager;
    [SerializeField] DieAnimation dieAnimation;

    private void Awake()
    {
        //dieAnimation = FindObjectOfType<DieAnimation>();
        uIScoreManager = FindObjectOfType<UIScoreManager>();
    }

    public void Die()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;

        uIScoreManager.Score += pointsForPlayerWhenDie;
        dieAnimation.TriggerDieAnimation();
        Destroy(gameObject, 1.183f);
    }



}
