using System;
using Godot;

namespace Rahja.Character.Player;

public partial class PlayerControllerSix : CharacterBody3D
{
    [Export] 
    private float _speed;
    
    public float GetSpeed() => _speed;
}