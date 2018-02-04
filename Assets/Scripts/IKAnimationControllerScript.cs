using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKAnimationControllerScript : MonoBehaviour
{

    public bool ikActive = false;
    public float offsetY;

    private Vector3 leftFootPos;
    private Vector3 rightFootPos;
    private Quaternion leftFootRot;
    private Quaternion rightFootRot;
    private float leftFootWeight;
    private float rightFootWeight;
    private Transform leftFoot;
    private Transform rightFoot;

    protected Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);

        leftFootRot = leftFoot.rotation;
        rightFootRot = rightFoot.rotation;

    }

    private void Update()
    {
        if (ikActive)
        {
            RaycastHit leftHit, rightHit;

            Vector3 leftPos = leftFoot.TransformPoint(Vector3.zero);
            Vector3 rightPos = rightFoot.TransformPoint(Vector3.zero);

            if (Physics.Raycast(leftPos, -Vector3.up, out leftHit, 1))
            {
                leftFootPos = leftHit.point;
                leftFootRot = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
            }

            if (Physics.Raycast(rightPos, -Vector3.up, out rightHit, 1))
            {
                rightFootPos = rightHit.point;
                rightFootRot = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
            }
        }
    }

    // a callback for calculating IK (inverse kinematics)
    private void OnAnimatorIK(int layerIndex)
    {
        if(animator && ikActive)
        {
            leftFootWeight = animator.GetFloat("LeftFoot");
            rightFootWeight = animator.GetFloat("RightFoot");

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);

            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);

            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPos + new Vector3(0, offsetY, 0));
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPos + new Vector3(0, offsetY, 0));

            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRot);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);
        }

        /*if (animator)
        {

            if (ikActive)
            {
                Vector3 desiredPosition = new Vector3(transform.position.x,
                                                groundObj.position.y + 0.14f,
                                                transform.position.z);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, desiredPosition);
                animator.SetIKRotation(AvatarIKGoal.LeftFoot, groundObj.rotation);
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
            }

        }*/
    }
    
}
