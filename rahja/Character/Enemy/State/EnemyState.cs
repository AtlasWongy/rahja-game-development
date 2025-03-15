using Godot;
using Godot.Collections;

namespace Rahja.Character.Enemy.State;

public abstract partial class EnemyState : Node
{
	[Signal]
	public delegate void FinishedEventHandler(string nextStatePath, Dictionary data);

	protected EnemyController EnemyController;
	private EnemyAnimationController _enemyAnimationController;
	
	public override async void _Ready()
	{
		await ToSignal(Owner, "ready");
		EnemyController = Owner as EnemyController;

		_enemyAnimationController = GetNode<EnemyAnimationController>("../../EnemyAnimationController");
		// When animation is finished
	}
	
	public virtual void HandleInput(InputEvent inputEvent) { }

	public virtual void Update(float delta) { }
    
	public virtual void PhysicsUpdate(float delta) { }

	public virtual void Enter(string previousStatePath, Dictionary data = null) { }

	public virtual void Exit() { }
    
	protected virtual void OnAnimationFinished(StringName stringName) { }
}
