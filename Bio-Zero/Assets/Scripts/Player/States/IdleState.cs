using Player.Info;

namespace Player.States
{
    public class IdleState : MovementBaseState
    {
        // Start is called before the first frame update
        public override void EnterState(PlayerController movement)
        {

        }

        public override void UpdateState(PlayerController movement)
        {
            if(movement.dir.magnitude > 0.1f)
            {
                movement.SwitchState(movement.Run);
            }
        }
    }
}
