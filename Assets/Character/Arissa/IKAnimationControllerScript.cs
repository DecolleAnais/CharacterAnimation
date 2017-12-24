using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKAnimationControllerScript : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform groundObj = null;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // a callback for calculating IK (inverse kinematics)
    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {

            if (ikActive)
            {
                if (groundObj != null)
                {
                    /*if(transform.position.y <= 0.0f)
                    {
                        Vector3 desiredPosition = new Vector3(transform.position.x,
                                                        groundObj.position.y + 0.14f,
                                                        transform.position.z);
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                        animator.SetIKPosition(AvatarIKGoal.LeftFoot, desiredPosition);
                        animator.SetIKRotation(AvatarIKGoal.LeftFoot, groundObj.rotation);

                    }*/
                }
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
            }

        }
    }
    
}
