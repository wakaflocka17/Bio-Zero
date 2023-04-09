using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchWeaponState : ActionBaseState
{
    // Start is called before the first frame update
    public override void EnterState(ActionStateManager actions)
    {
        actions.rHandAim.weight = 0;
        actions.lHandIK.weight = 0;
        actions.animator.SetTrigger("Switch"); 
    }

    public override void UpdateState(ActionStateManager actions)
    {
       
    } 
          
} 
