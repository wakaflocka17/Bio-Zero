public abstract class MovementBaseState
{
    // Start is called before the first frame update
    public abstract void EnterState(PlayerController movement); 

    public abstract void UpdateState(PlayerController movement);
}