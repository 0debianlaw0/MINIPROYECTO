using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : MovementBaseStates
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if(movement.direction.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            else movement.SwitchState(movement.Walk);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) movement.SwitchState(movement.Crouch);
    }  
}
