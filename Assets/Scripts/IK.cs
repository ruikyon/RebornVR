using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

//Name of class must be name of file as well

public class IK : MonoBehaviour
{
    protected Animator animator;

    public Transform bodyObj = null;
    public Transform leftFootObj = null;
    public Transform rightFootObj = null;
    public Transform leftHandObj = null;
    public Transform rightHandObj = null;
    public Transform lookAtObj = null;

    public float leftFootWeightPosition = 1;
    public float leftFootWeightRotation = 1;

    public float rightFootWeightPosition = 1;
    public float rightFootWeightRotation = 1;

    public float leftHandWeightPosition = 1;
    public float leftHandWeightRotation = 1;

    public float rightHandWeightPosition = 1;
    public float rightHandWeightRotation = 1;

    public float lookAtWeight = 1.0f;

    private Quaternion plus = new Quaternion(0, 0, 1, 90);
    private Quaternion minus = new Quaternion(0, 0, 1, -90);


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (!animator)
        {
            return;
        }

        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeightPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeightRotation);

        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeightPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeightRotation);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeightPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeightRotation);

        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeightPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeightRotation);

        animator.SetLookAtWeight(lookAtWeight, 0.3f, 0.6f, 1.0f, 0.5f);

        if (bodyObj != null)
        {
            animator.bodyPosition = bodyObj.position;
            animator.bodyRotation = bodyObj.rotation;
        }

        if (leftFootObj != null)
        {
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation);
        }

        if (rightFootObj != null)
        {
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation);
        }

        if (leftHandObj != null)
        {
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation*plus);
        }

        if (rightHandObj != null)
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation*minus);
        }

        if (lookAtObj != null)
        {
            animator.SetLookAtPosition(lookAtObj.position);
        }
    }
}