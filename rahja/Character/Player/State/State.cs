using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public abstract partial class State : Node
{
    
    [Signal]
    public delegate void FinishedEventHandler(string nextStatePath, Dictionary data);
    
    protected PlayerControllerSix Player;
    protected AnimationController AnimationController;
    
    private float _turnDirection;
    
    public override async void _Ready()
    {
        await ToSignal(Owner, "ready");
        Player = Owner as PlayerControllerSix;
        if (Player != null) GD.Print(Player.GetClass());
        
        AnimationController = GetNode<AnimationController>("../../AnimationController");
        AnimationController.GetAnimationTree().AnimationFinished += OnAnimationFinished;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is not InputEventMouseMotion eventMouseMotion) return;
        if (eventMouseMotion.Relative.X > 0)
        {
            _turnDirection = 1;
        }
        else
        {
            _turnDirection = -1;
        }
    }

    protected void RotatePlayer()
    {
        Player.Rotate(new Vector3(0, 1.0f, 0), 0.1f * _turnDirection);
        _turnDirection = 0f;
    }

    public virtual void HandleInput(InputEvent inputEvent) { }

    public virtual void Update(float delta) { }
    
    public virtual void PhysicsUpdate(float delta) { }

    public virtual void Enter(string previousStatePath, Dictionary data = null) { }

    public virtual void Exit() { }
    
    protected virtual void OnAnimationFinished(StringName stringName) { }
}

/* ========================================== */

// public abstract partial class State: Node
// {
// 	[Signal]
// 	public delegate void FinishedEventHandler(string nextStatePath, Dictionary input);
// 	
// 	public abstract void HandleInput(InputEvent input);
// 	
// 	public abstract void Update(double deltaTime);
// 	
// 	public abstract void PhysicsUpdate(double deltaTime);
// 	
// 	public abstract void Enter(string previousStatePath, Dictionary input);
// 	
// 	public abstract void Exit();
// }

/* ========================================== */

// internal interface IState
// {
// 	[Signal]
// 	public delegate void FinishedEventHandler(string nextStatePath, Dictionary input);
//
// 	void HandleInput(InputEvent inputEvent);
//
// 	void Update(double deltaTime);
//
// 	void PhysicsUpdate(double deltaTime);
//
// 	void Enter(string previousStatePath, Dictionary input);
//
// 	void Exit();
// };
