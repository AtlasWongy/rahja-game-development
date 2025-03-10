using System;
using Godot;

namespace Rahja.Character.Player;

public partial class PlayerControllerSix : CharacterBody3D
{
    [Signal] public delegate void MovementSignalEventHandler(bool isMoving);
    [Signal] public delegate void ParrySignalEventHandler();

    public float Speed { get; private set; } = 5.0f;
    // private float _speed = 5f;
    private float _turnDir;

    // public override void _Input(InputEvent @event)
    // {
    //     if (@event is not InputEventMouseMotion eventMouseMotion) return;
    //     if (eventMouseMotion.Relative.X > 0)
    //     {
    //         _turnDir = 1;
    //     }
    //     else
    //     {
    //         _turnDir = -1;
    //     }
    // }

    public override void _PhysicsProcess(double delta)
    {
        // Rotate(new Vector3(0, 1.0f, 0), 0.1f * _turnDir);
        // _turnDir = 0f;
        //
        // if (Input.IsActionPressed("movement"))
        // {
        //     Velocity = Transform.Basis.Z * _speed;
        //     EmitSignal(SignalName.MovementSignal, true);
        // }
        // else
        // {
        //     Velocity = Vector3.Zero;
        //     EmitSignal(SignalName.MovementSignal, false);
        // }
        //
        // if (Input.IsActionPressed("parry"))
        // {
        //     EmitSignal(SignalName.ParrySignal);
        // }
        //
        // MoveAndSlide();
    }
}