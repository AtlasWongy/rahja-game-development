using System;
using Godot;

namespace Rahja.Character.Player.State;

public abstract partial class PlayerState: Node
{
    private Player _player;
    
    public override async void _Ready()
    {
        await ToSignal(Owner, "ready");
        _player = Owner as Player;
        if (_player != null) GD.Print(_player.GetClass());
    }
}