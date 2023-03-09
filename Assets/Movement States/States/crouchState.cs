using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchState : MovementBaseStates
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Crouching", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (movement.direction.magnitude < 0.1f) ExitState(movement, movement.Idle);
            else ExitState(movement, movement.Walk);
        }

        if (movement.verticalInput < 0) movement.currentMoveSpeed = movement.crouchBackSpeed;
        else movement.currentMoveSpeed = movement.crouchSpeed;
    }

    void ExitState(MovementStateManager movement, MovementBaseStates state)
    {
        movement.animator.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
