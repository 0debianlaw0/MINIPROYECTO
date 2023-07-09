using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState
{
    public override void EnterState(ActionStateManager actions)
    {
 
    }

    public override void UpdateState(ActionStateManager actions)
    {
        actions.rHandAim.weight = Mathf.Lerp(actions.rHandAim.weight, 1, 10 * Time.deltaTime);
        actions.lHandIK.weight = Mathf.Lerp(actions.lHandIK.weight, 1, 10 * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        //{
            //actions.SwitchState(actions.Reload);
       //}
    }

    //bool CanReload(ActionStateManager action)
    //{
        //if (action.ammo.currentAmmo == action.ammo.clipSize && action.currentWeapon.activeSelf == true) return false;
        //else if (action.ammo.extraAmmo == 0 && action.currentWeapon.activeSelf == true) return false;
        //if (action.ammo2.currentAmmo == action.ammo2.clipSize && action.currentWeapon2.activeSelf == true) return false;
        //else if (action.ammo2.extraAmmo == 0 && action.currentWeapon2.activeSelf == true) return false;
        //else return true;
    //}
}
