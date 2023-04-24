using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementBaseStates
{
    public override void EnterState(MovementStateManager movement)
    {
        if (movement.previousState == movement.Idle) movement.animator.SetTrigger("IdleJump");
        else if (movement.previousState == movement.Walk || movement.previousState == movement.Run) movement.animator.SetTrigger("RunJump");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.jumped && movement.IsGrounded())
        {
            movement.jumped = false;
            if (movement.horizontalInput == 0 && movement.verticalInput == 0) movement.SwitchState(movement.Idle);
            else if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            else movement.SwitchState(movement.Walk);
        }
    }
}
