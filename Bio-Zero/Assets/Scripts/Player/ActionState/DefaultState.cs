using UnityEngine;

namespace Player.ActionState
{
    public class DefaultState : ActionBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(ActionStateManager actions)
        {
        
            actions.rHandAim.weight = 1;
            actions.lHandIK.weight = 1;
        

        }

        public override void UpdateState(ActionStateManager actions)
        {
            //ricarica arriva con 0
            //lo switch arriva con 1
            actions.rHandAim.weight = Mathf.Lerp(actions.rHandAim.weight, 1, 5 * Time.deltaTime);
            actions.lHandIK.weight = Mathf.Lerp(actions.lHandIK.weight, 1, 5 * Time.deltaTime);
            
            if(Input.GetKeyDown(KeyCode.R) && CanReload(actions))
            {
                Debug.Log("ricarica");
                actions.SwitchState(actions.Reload);
            }
            // else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
            // || Input.GetKeyDown(KeyCode.Alpha3))
            // {
            //     actions.SwitchState(actions.ChangeWeapon);
            // }


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
}
