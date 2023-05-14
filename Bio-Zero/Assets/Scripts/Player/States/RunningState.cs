using Player.Info;

namespace Player.States
{
    public class RunningState : MovementBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(PlayerController movement)
        {
            movement.animator.SetBool("isRunning", true);
        }

        public override void UpdateState(PlayerController movement)
        {
        
        }
    }
}