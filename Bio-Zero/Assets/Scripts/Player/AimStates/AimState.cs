using UnityEngine;

namespace Player.AimStates
{
    public class AimState : AimBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(AimStateManager aim)
        {
            aim.animator.SetBool("isAiming", true);
            aim.currentFov = aim.adsFov;
        }

        public override void UpdateState(AimStateManager aim)
        {
            if(Input.GetKeyUp(KeyCode.Mouse1)) 
                aim.SwitchState(aim.Hip);
        }
    }
}
