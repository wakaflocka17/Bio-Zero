using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    // Start is called before the first frame update
    public override void EnterState(AimStateManager aim)
    {
        aim.animator.SetBool("isAiming", false);
        aim.currentFov = aim.hipFov;
    }

    public override void UpdateState(AimStateManager aim)
    {
        if(Input.GetKey(KeyCode.Mouse1)) 
            aim.SwitchState(aim.Aim);
    }
}
