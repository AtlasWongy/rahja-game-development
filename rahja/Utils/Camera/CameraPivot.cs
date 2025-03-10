using Godot;
using Rahja.Character.Player;

namespace Rahja.Utils.Camera;

public partial class CameraPivot : Node3D
{
	[Export] private PlayerControllerSix _player;

	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition = GlobalPosition.Lerp(_player.GlobalPosition, 0.5f);
	}
}
