using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningState : MovementBaseStates
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Running", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if (movement.direction.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (movement.verticalInput < 0) movement.currentMoveSpeed = movement.runBackSpeed;
        else movement.currentMoveSpeed = movement.runSpeed;
    }

    void ExitState(MovementStateManager movement, MovementBaseStates state)
    {
        movement.animator.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
