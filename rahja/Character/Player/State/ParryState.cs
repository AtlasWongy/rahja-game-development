﻿using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public partial class ParryState: State
{
    public override void PhysicsUpdate(float delta)
    {
        // Check for the collision
        if (Input.IsActionJustPressed("riposte") /* && Must check for successful parry */)
        {
            EmitSignal("Finished", "Riposte", new Dictionary());
        }
    }
    
    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        Player.Velocity = Vector3.Zero;
        AnimationController.EmitSignal("ParrySignal");
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