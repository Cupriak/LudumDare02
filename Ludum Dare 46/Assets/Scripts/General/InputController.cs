using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static float HorizontalMovement { get; private set; }
    public static float VerticalMovement { get; private set; }
    public static bool Jump { get; private set; }
    public static bool Interact { get; private set; }
    public static bool Shoot { get; private set; }
    public static bool Menu { get; private set; }
    public static bool Pause { get; private set; }
    public static bool MenuFreeze { get; private set; }
    private void GetHorizontalMovementInput()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
    }
    private void GetVerticalMovementInput()
    {
        VerticalMovement = Input.GetAxisRaw("Vertical");
    }
    private void GetJumpInput()
    {
        Jump = Input.GetButton("Jump");
    }
    private void GetInteractInput()
    {
        Interact = Input.GetButton("Interact");
    }
    private void GetShootInput()
    {
        Shoot = Input.GetButton("Shoot");
    }
    private void GetMenuInput()
    {
        Menu = Input.GetButtonDown("Menu");
    }
    private void GetPauseInput()
    {
        Pause = Input.GetButtonDown("Pause");
    }
    private void GetMenuFreeze()
    {
        MenuFreeze = UIController.GetInstance().menuUI.activeSelf ? true : false;
    }
    private void Update()
    {
        GetHorizontalMovementInput();
        GetVerticalMovementInput();
        GetJumpInput();
        GetInteractInput();
        GetShootInput();
        GetMenuInput();
        GetPauseInput();
        GetMenuFreeze();
    }
}
