using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationPlayerController : MonoBehaviour
{
    Animator animator;
    DoubleJump dj;
    void Start()
    {
        dj = GetComponent<DoubleJump>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
      if(dj.IsGrounded==true && (Input.GetKey("w") || Input.GetKey("s")))

        {
            animator.SetBool("IsCrawling", true);
        }
       else
        {
            animator.SetBool("IsCrawling", false);
        }
    }
}
