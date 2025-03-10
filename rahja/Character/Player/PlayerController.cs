using Godot;
using System;
namespace Rahja.Character.Player;
public partial class PlayerController : CharacterBody3D
{
	private Vector3 _input;
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_left") || @event.IsActionPressed("ui_right"))
		{
			_input.Y = Input.GetAxis("ui_left", "ui_right");
		}
		else if (@event.IsActionReleased("ui_left") || @event.IsActionReleased("ui_right"))
		{
			_input = Vector3.Zero;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_input != Vector3.Zero)
		{
			Transform3D transform = Transform;

			transform.Basis = transform.Basis.Rotated(_input, 0.1f);
			Transform = transform;
		}

		if (Input.IsActionPressed("movement"))
		{
			Velocity = Velocity.Lerp(Transform.Basis.Z * 500.0f, (float)delta * 5.0f);
		}
		else
		{
			Velocity = Vector3.Zero;
		}
		
		MoveAndSlide();
	}
}
