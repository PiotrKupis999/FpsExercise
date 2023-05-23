using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayAnimationOnce();
    }

    public void PlayAnimationOnce()
    {
        //animator.SetTrigger("PlayAnimation");
    }
}
