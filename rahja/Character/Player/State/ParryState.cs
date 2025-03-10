using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;


public partial class ParryState: State
{
    private AnimationPlayer _animationPlayer;
    
    public override void PhysicsUpdate(float delta)
    {
        // Check for the collision
    }
    
    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        Player.Velocity = Vector3.Zero;
        Player.EmitSignal("ParrySignal");
    }
}