using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool wantToJump = false;
    bool wantToCrouch = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
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
