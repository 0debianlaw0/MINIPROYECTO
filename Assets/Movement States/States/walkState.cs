using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState : MovementBaseStates
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        else if (Input.GetKeyDown(KeyCode.LeftControl)) ExitState(movement, movement.Crouch);
        else if (movement.direction.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (movement.verticalInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //movement.previousState = this;
            //ExitState(movement, movement.Jump);
        //}
    }

    void ExitState(MovementStateManager movement, MovementBaseStates state)
    {
        movement.animator.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
