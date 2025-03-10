using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public partial class IdleState: State
{
    public override void PhysicsUpdate(float delta)
    {
        RotatePlayer();
        if (Input.IsActionPressed("movement"))
        {
            EmitSignal("Finished", "Move", new Dictionary());
        }
        else if (Input.IsActionPressed("parry"))
        {
            EmitSignal("Finished", "Parry", new Dictionary());
        }
    }

    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        Player.Velocity = Vector3.Zero;
        Player.EmitSignal("MovementSignal", false);
    }
}