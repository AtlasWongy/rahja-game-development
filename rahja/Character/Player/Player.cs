using System;
using Godot;

namespace Rahja.Character.Player;

public partial class Player : CharacterBody2D
{
	[Export] 
	private float _speed = 500.0f;

	[Export] 
	private float _gravity = 4000.0f;

	[Export] 
	private float _jumpImpulse = 1800.0f;
}

