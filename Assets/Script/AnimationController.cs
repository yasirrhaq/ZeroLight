using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attack();
    }

    void attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isHit", true);
            anim.SetBool("isLeftClick", true);
        }else if (Input.GetMouseButtonUp(0))
        {
            resetAnimation();
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("isHit", true);
            anim.SetBool("isRightClick", true);
        }else if (Input.GetMouseButtonUp(1))
        {
            resetAnimation();
        }
    }

    public void resetAnimation()
    {
        anim.SetBool("isHit", false);
        anim.SetBool("isRightClick", false);
        anim.SetBool("isLeftClick", false);
    }
}
