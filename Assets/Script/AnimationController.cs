using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    //public CharacterController characterController;
    void Update()
    {
        attack();
    }

    public void attack()
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

    public void Walking()
    {
        //if (characterController.horizontalMove> 0)
        //{
        //    anim.SetFloat("x", characterController.horizontalMove);
        //}
        //else if(characterController.horizontalMove<0)
        //{
        //    anim.SetFloat("x", characterController.horizontalMove);
        //}

        //if (characterController.verticalMove>0)
        //{
        //    anim.SetFloat("y", characterController.verticalMove);

        //}else if (characterController.verticalMove < 0)
        //{
        //    anim.SetFloat("y", characterController.verticalMove);
        //}
    }

    public void resetAnimation()
    {
        anim.SetBool("isHit", false);
        anim.SetBool("isRightClick", false);
        anim.SetBool("isLeftClick", false);
    }
}
