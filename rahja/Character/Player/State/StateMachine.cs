using System;
using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace Rahja.Character.Player.State;

public partial class StateMachine: Node
{

	[Export] 
	private State _initialState;

	private State _state;
	
	public override async void _Ready()
	{
		_state = _initialState ?? GetChild<State>(0);

		var allStates = FindChildren("*", "Node");
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

	/* =====================================*/
	// private IState _state;
	//
	// public override void _Ready()
	// {
	// 	// _state = _initialState ?? GetChild<IState>(0);
	// 	try
	// 	{
	// 		_state = GetChild<IState>(0);
	// 	}
	// 	catch (Exception e)
	// 	{
	// 		Console.WriteLine(e);
	// 		throw;
	// 	}
	//
	// 	foreach (var child in GetChildren())
	// 	{
	// 		GD.Print(child);
	// 	}
	//
	// 	// foreach (var child in FindChildren("*", "IState"))
	// 	// {
	// 	// 	var node = (IState)child;
	// 	// 	GD.Print(node);
	// 	// 	if (node != null)
	// 	// 	{
	// 	// 		GD.Print("Everything is ok");
	// 	// 	}
	// 	// 	else
	// 	// 	{
	// 	// 		GD.Print("Everything is ok");
	// 	// 	}
	// 	// }
	// }

	/* ============================== */
	// [Export] 
	// private State _initialState;
	//
	// private State _state;
	//
	// public override async void _Ready()
	// {
	// 	_state = _initialState ?? GetChild<State>(0);
	//
	// 	foreach (var child in FindChildren("*", "State"))
	// 	{
	// 		var node = (State)child;
	// 		node.Finished += OnTransitionToNextState;
	// 	}
	// 	
	// 	await ToSignal(Owner, "ready");
	// 	_state.Enter("", null);
	// }
	//
	// private void UnhandledInput(InputEvent inputEvent)
	// {
	// 	_state.HandleInput(inputEvent);
	// }
	//
	// private void Process(float delta)
	// {
	// 	_state.Update(delta);
	// }
	//
	// private void PhysicsProcess(float delta)
	// {
	// 	_state.PhysicsUpdate(delta);
	// }
	//
	// private void OnTransitionToNextState(string targetStatePath, Dictionary input)
	// {
	// 	if (!HasNode(targetStatePath))
	// 	{
	// 		Console.Error.WriteLine(Owner.Name + ": Trying to transition to state " + targetStatePath +
	// 								" but it doesn't exist.");
	// 	}
	// 	
	// 	String previousStatePath = targetStatePath;
	// 	_state.Exit();
	// 	_state = GetNode<State>(targetStatePath);
	// 	_state.Enter(previousStatePath, input);
	// }

}
