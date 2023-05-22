using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using WeaponScripts;

namespace Player.ActionState
{
    public class ReloadState : ActionBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(ActionStateManager actions)
        {
       
            actions.rHandAim.weight = 0;
            actions.lHandIK.weight = 0;
            Debug.Log(actions.lHandIK.weight);
            actions.animator.SetTrigger("Reload");
        

        }

        public override void UpdateState(ActionStateManager actions)
        {
        

        }
    }
}
