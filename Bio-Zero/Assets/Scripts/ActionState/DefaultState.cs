using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState
{
    // Start is called before the first frame update
    public override void EnterState(ActionStateManager actions)
    {
        actions.rHandAim.weight = 1;
        actions.lHandIK.weight = 1;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    public override void UpdateState(ActionStateManager actions)
    {
        actions.rHandAim.weight = Mathf.Lerp(actions.rHandAim.weight, 1, 5 * Time.deltaTime);
        actions.lHandIK.weight = Mathf.Lerp(actions.lHandIK.weight, 1, 5 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        {
            actions.SwitchState(actions.Reload);
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    bool CanReload(ActionStateManager action)
    {
        if(action.ammo.currentAmmo == action.ammo.clipSize)
            return false;
        else if(action.ammo.extraAmmo == 0)
            return false;
        else 
            return true;
    }
}
