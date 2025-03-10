using Godot;

namespace Rahja.Character.Player;

public partial class PlayerControllerTwo : CharacterBody3D
{
    private Vector3 _input;

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("movement_update"))
        {
            _input.X = Input.GetAxis("ui_left", "ui_right");
            _input.Z = Input.GetAxis("ui_down", "ui_up");
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
            var currentPos = Position;
            var currentScale = Transform.Basis.Scale;
            // var targetPos = new Vector3(2, 0.5f, 1.2f);
            var targetPos = (currentPos * _input) + new Vector3(1.0f, 0, 1.0f);
            
            Transform = Transform.LookingAt(targetPos, Vector3.Up, true);
            Transform = Transform.Scaled(currentScale);
            Position = currentPos;
            // GD.Print("New Transform: " + Transform);

        }
        // GD.Print("My Transform: ", Transform.Origin);
        
        // GD.Print($"Current Transform Basis: {Transform.Basis}");
        // Look();
        // if (Input.IsActionPressed("movement"))
        // {
        //     Velocity = Velocity.Lerp(Transform.Basis.Z * 500.0f, (float)delta * 5.0f);
        // }
        // else
        // {
        //     Velocity = Vector3.Zero;
        // }
		
        MoveAndSlide();
    }

    private void Look()
    {
        // var relative = (Transform.Basis.Y + _input) - Transform.Basis.Y;
        // var rot = Transform3D.Identity.LookingAt(relative, Vector3.Up);
        //
        // Transform = rot;
        if (_input == Vector3.Zero) return;

        var rot = Transform3D.Identity.LookingAt(_input, Vector3.Up);
        Transform = rot;
        
    }
    
}