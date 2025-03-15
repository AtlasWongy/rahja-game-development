using Godot;
using Godot.Collections;

namespace Rahja.Character.Enemy.State;

public partial class AttackState: EnemyState
{
    [Signal]
    public delegate void AttackCompleteSignalEventHandler();
    
    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        // Emit Signal to play Attack Animation
    }

    public override void Exit()
    {
        EmitSignal(SignalName.AttackCompleteSignal);
    }
}