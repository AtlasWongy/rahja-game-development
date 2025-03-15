using Godot;
using Godot.Collections;
using Rahja.Character.Player.State;

namespace Rahja.Utils.StateMachine;

public partial class StateMachine: Node
{

	[Export] 
	private State _initialState;

	private State _state;
	
	public override async void _Ready()
	{
		_state = _initialState ?? GetChild<State>(0);

		var allStates = FindChildren("*");
		foreach (var stateNode in allStates)
		{
			var state = (State)stateNode;
			state.Finished += OnTransitionToNextState;
		}
		
		await ToSignal(Owner, "ready");
		_state.Enter("");
	}

	private void UnhandledInput(InputEvent inputEvent)
	{
		_state.HandleInput(inputEvent);
	}

	private void Process(float delta)
	{
		_state.Update(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		_state.PhysicsUpdate((float) delta);
	}

	private void OnTransitionToNextState(string targetStatePath, Dictionary data = null)
	{
		if (!HasNode(targetStatePath))
		{
			GD.PrintErr(Owner.Name + ": Trying to transition to state " + targetStatePath + " But it does not exist.");
		}

		var previousStatePath = _state.Name;
		_state.Exit();
		_state = GetNode<State>(targetStatePath);
		_state.Enter(previousStatePath, data);

	}
}
