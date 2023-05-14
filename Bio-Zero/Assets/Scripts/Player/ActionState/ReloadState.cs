namespace Player.ActionState
{
    public class ReloadState : ActionBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(ActionStateManager actions)
        {
       
            actions.rHandAim.weight = 0;
            actions.lHandIK.weight = 0;
            actions.animator.SetTrigger("Reload");
        

        }

        public override void UpdateState(ActionStateManager actions)
        {
        

        }
    }
}
