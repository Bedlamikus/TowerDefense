using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Run()
    {
        animator.SetBool("Run", true);
    }

    public void Stop()
    {
        animator.SetBool("Run", false);
    }

    private void ChangeIdle()
    {
        animator.SetBool("Idle1", true);
        animator.SetBool("Idle1", false);
    }
}
