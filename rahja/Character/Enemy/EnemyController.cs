using Godot;
using Rahja.Character.Enemy.State;
using Rahja.Character.Player;

namespace Rahja.Character.Enemy;

public partial class EnemyController : CharacterBody3D
{
	// For testing purpose only, we will hold a reference to the player
	[Export] 
	private PlayerControllerSix _player;

	[Export] 
	private Timer _attackCoolDownTimer;
	
	// Temporary Injection: Perhaps find a better way to inject this dependency
	[Export] 
	private AttackState _attackState;
	
	public bool IsAggressive { get; private set; }
	public bool CanAttack { get; set; }

	public override void _Ready()
	{
		_attackCoolDownTimer.Timeout += OnAttackTimerTimeout;
		_attackState.AttackCompleteSignal += OnAttackComplete;
	}

	// Detect the player
	// Temporary Method: Distance checker
	// Perhaps can move the Player's LookingAt method over to the Controller instead of the state
	private void CheckDistanceBetweenPlayer()
	{
		var distanceFromPlayer = GlobalPosition.DistanceTo(_player.GlobalPosition);
		if (distanceFromPlayer <= 0.35f)
		{
			LookAt(_player.GlobalPosition, Vector3.Up);
		}
	}
	
	// Start the cooldown
	private void OnAttackComplete()
	{
		CanAttack = false;
		_attackCoolDownTimer.Start();
	}
	
	
	// Reset Enemy Attack Cooldown
	private void OnAttackTimerTimeout()
	{
		CanAttack = true;
	}
	
}
