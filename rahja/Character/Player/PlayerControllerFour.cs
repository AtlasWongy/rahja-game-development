using Godot;
using System;

namespace Rahja.Character.Player;

public partial class PlayerControllerFour : CharacterBody3D
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
        

        if (Input.IsActionPressed("movement_update"))
        {
            // Velocity = Velocity.Lerp(adjustedInput * _speed, (float)delta * 100f);
            // GD.Print("Velocity: " + Velocity);
            
            // GD.Print($"Before normalization: ${adjustedInput}");
            // GD.Print($"After Normalization: ${adjustedInput.Normalized()}");
            
            GD.Print($"The raw input is {_input}");
            var adjustedInput = ConvertCartesianToIso(_input);
            GD.Print($"The adjusted input is: {adjustedInput}");
            // GD.Print($"With Magnitude: {adjustedInput * _speed}");
            
            Velocity = Velocity.Lerp(adjustedInput * _speed, (float)delta * 50.0f);
            // GD.Print("Velocity: " + Velocity);
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

        if (z % 1 != 0 && z < 1)
        {
            var res = Math.Abs(z);
            z = Mathf.Ceil(res) * -1;
        }
        else if (z % 1 != 0 && z > 0)
        {
            z = Math.Abs(z);
        }
        
        return new Vector3(x, 0, z);
    }
}