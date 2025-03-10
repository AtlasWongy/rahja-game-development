using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public partial class MoveState: State
{
    public override void PhysicsUpdate(float delta)
    {
        RotatePlayer();
        if (Input.IsActionPressed("movement"))
        {
            Player.Velocity = Player.Transform.Basis.Z * Player.Speed;
            Player.MoveAndSlide();
        }
        else
        {
            EmitSignal("Finished", "Idle", new Dictionary());
        }
    }

    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        Player.EmitSignal("MovementSignal", true);
    }
}