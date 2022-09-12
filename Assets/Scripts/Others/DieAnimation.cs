using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnimation : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerDieAnimation()
    {
        
            animator.SetTrigger("Die");
        
        
    }
}
