using Godot;

namespace Rahja.Character.Player;

public partial class AnimationController : Node
{
    [Export] private AnimationTree _animationTree = null!;
    [Export] private PlayerControllerSix _playerBody3D = null!;

    private AnimationNodeStateMachinePlayback _animationStateMachine;
    public override void _Ready()
    {
        _animationStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");
        _playerBody3D.MovementSignal += OnSetMovement;
        _playerBody3D.ParrySignal += OnSetParry;
    }
    private void OnSetMovement(bool isMoving)
    {
        if (isMoving)
        {
            _animationStateMachine.Travel("Running_A"); 
        }
        else
        {
            _animationStateMachine.Travel("Idle");
        }
    }

    private void OnSetParry()
    {
        _animationStateMachine.Travel("Blocking");
    }
}