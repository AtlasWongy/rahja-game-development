using Godot;
using System;

namespace Rahja.Character.Player;

public partial class PlayerControllerThree : CharacterBody3D
{
    private float _speed = 5f;
    private Vector3 _input;

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("movement_update"))
        {
            _input.X = Input.GetAxis("ui_left", "ui_right");
            _input.Z = Input.GetAxis("ui_up", "ui_down");
        }
        else if (@event.IsActionReleased("movement_update"))
        {
            _input = Vector3.Zero;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_input != Vector3.Zero)
        {
            var adjustedInput = ConvertCartesianToIso(_input);
            LookAt(new Vector3(adjustedInput.X, Position.Y, adjustedInput.Z), Vector3.Up);
            RotateObjectLocal(Vector3.Up, (float) Math.PI);
        }

        if (Input.IsActionPressed("movement"))
        {
            Velocity = Transform.Basis.Z * _speed;
            GD.Print("Position: ", GlobalPosition);
        }
        else
        {
            Velocity = Vector3.Zero;
        }
        
        MoveAndSlide();
    }

    private Vector3 ConvertCartesianToIso(Vector3 cartesian)
    {
        var x = cartesian.X + cartesian.Z;
        var z = - (cartesian.X - cartesian.Z) / 2;
        
        return new Vector3(x, Position.Y, z);
    }
}