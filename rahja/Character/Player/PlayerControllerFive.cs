using System;
using Godot;

namespace Rahja.Character.Player;

public partial class PlayerControllerFive : CharacterBody3D
{
    
    private Vector2 _mouseRelativePosition = Vector2.Zero;
    private float _rot;
    private float _mouseSensitivity = 0.65f;
    private float _turnRate = 15.0f;
    private float _speed = 5f;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion eventMouseMotion)
        {
            _rot += eventMouseMotion.Relative.X * _mouseSensitivity;
        }
    }
    
    public override void _PhysicsProcess(double delta)
    {
        // GD.Print($"Current Rotation: {RotationDegrees.Y}");
        // RotationDegrees = RotationDegrees.Lerp(new Vector3(0, 181.0f, 0), _turnRate * (float)delta);
        // MoveAndSlide();

        // GD.Print("The rotation value: " + _rot);
        // RotationDegrees = RotationDegrees.Lerp(new Vector3(0, _rot * _mouseSensitivity, 0), _turnRate * (float)delta);
        // GD.Print("The current rotation: ", RotationDegrees);
        // //
        // if (Input.IsActionPressed("movement"))
        // {
        //     Velocity = Transform.Basis.Z * _speed;
        // }
        // else
        // {
        //     Velocity = Vector3.Zero;
        // }
        // //
        // MoveAndCollide(Velocity);
    }
}