using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public partial class RiposteState: State
{
    public override void PhysicsUpdate(float delta)
    {
        // Check for the collision
        // Can cancel the attack by dashing or parrying again
        if (Input.IsActionJustPressed("riposte"))
        {
            EmitSignal("Finished", "Parry", new Dictionary());
        }
    }
    
    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        Player.Velocity = Vector3.Zero;
        AnimationController.EmitSignal("RiposteSignal");  
    }
    
    protected override void OnAnimationFinished(StringName stringName)
    {
        if (Input.IsActionPressed("movement"))
        {
            EmitSignal("Finished", "Move", new Dictionary());
        }
        else
        {
            EmitSignal("Finished", "Idle", new Dictionary());
        }
    }
}