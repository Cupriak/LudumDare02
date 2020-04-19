using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool wantToJump = false;
    bool wantToCrouch = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();

    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = InputController.HorizontalMovement * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (InputController.Jump)
        {  
            wantToJump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            wantToCrouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            wantToCrouch = false;
        }
    }


    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, wantToCrouch, wantToJump);
        wantToJump = false;
    }
}
