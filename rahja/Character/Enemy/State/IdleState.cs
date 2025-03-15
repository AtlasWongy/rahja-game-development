using Godot;
using Godot.Collections;

namespace Rahja.Character.Enemy.State;

public partial class IdleState: EnemyState
{
    public override void PhysicsUpdate(float delta)
    {
        if (EnemyController.CanAttack)
        {
            EmitSignal("Finished", "Attack", new Dictionary());
        }
    }

    public override void Enter(string previousStatePath, Dictionary data = null)
    {
        EnemyController.Velocity = Vector3.Zero;
        // Emit Signal to play Idle Animation
    }
    
    // OnPlayerNearOrAttackCoolDownEnd() {} => subsribe
}