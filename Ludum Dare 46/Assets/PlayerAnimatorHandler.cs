using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHandler : MonoBehaviour
{
    private Animator animator;
    private CharacterController2D characterController2D;
    private InputController inputController;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputController = GetComponent<InputController>();
        characterController2D = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("isWalking", Mathf.Abs(InputController.HorizontalMovement));
        animator.SetBool("wantToJump", InputController.Jump);
        animator.SetBool("isGrounded", characterController2D.m_Grounded);
    }
}
