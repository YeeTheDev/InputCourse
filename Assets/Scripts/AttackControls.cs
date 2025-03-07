using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] private GatherInput input;

    private Animator animator;
    public bool attackStarted;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (input.tryToAttack)
        {
            if (attackStarted == false)
            {
                attackStarted = true;
                animator.SetBool("Attack", attackStarted);
            }

            input.tryToAttack = false;
        }
    }

    public void ResetAttack()
    {
        attackStarted = false;
        animator.SetBool("Attack", attackStarted);
    }
}
