using Godot;

namespace Rahja.Character.Player;

public partial class AnimationController : Node
{
    [Signal] public delegate void MovementSignalEventHandler(bool isMoving);
    [Signal] public delegate void ParrySignalEventHandler();
    [Signal] public delegate void RiposteSignalEventHandler();
    
    [Export] private AnimationTree _animationTree = null!;
    
    private AnimationNodeStateMachinePlayback _animationStateMachine;
    
    public override void _Ready()
    {
        _animationStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");

        MovementSignal += OnSetMovement;
        ParrySignal += OnSetParry;
        RiposteSignal += OnSetRiposte;
    }
    
    public AnimationTree GetAnimationTree() => _animationTree;
    
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

    private void OnSetRiposte()
    {
        _animationStateMachine.Travel("1H_Melee_Attack_Chop");
    }
    
    // [Export] private AnimationTree _animationTree = null!;
    // [Export] private PlayerControllerSix _playerBody3D = null!;
    //
    // private AnimationNodeStateMachinePlayback _animationStateMachine;
    // public override void _Ready()
    // {
    //     _animationStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");
    //     _playerBody3D.MovementSignal += OnSetMovement;
    //     _playerBody3D.ParrySignal += OnSetParry;
    // }
    // private void OnSetMovement(bool isMoving)
    // {
    //     if (isMoving)
    //     {
    //         _animationStateMachine.Travel("Running_A"); 
    //     }
    //     else
    //     {
    //         _animationStateMachine.Travel("Idle");
    //     }
    // }
    //
    // private void OnSetParry()
    // {
    //     _animationStateMachine.Travel("Blocking");
    // }
}