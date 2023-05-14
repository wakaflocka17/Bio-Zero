
namespace Player.AimStates
{
    public abstract class AimBaseState 
    {
        // Start is called before the first frame update
        public abstract void EnterState(AimStateManager aim);

        public abstract void UpdateState(AimStateManager aim);
    }
}
