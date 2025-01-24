using Godot;
using System;

public partial class Character : CharacterBody2D {
    private StateMachine _MovingStateMachine;
    private StateMachine _BubbleStateMachine;

    public override void _Ready() {
        _MovingStateMachine = GetNode<StateMachine>("MovingStateMachine");
        _BubbleStateMachine = GetNode<StateMachine>("BubbleStateMachine");

        // Initialize states
        _MovingStateMachine.ChangeState("IdleState");
        _BubbleStateMachine.ChangeState("DefaultState");
    }

    public override void _Process(double delta) {
        // Handle blocking input
        if (Input.IsActionJustPressed("block")) {
            _BubbleStateMachine.ChangeState("BlockingState");
        }
    }
}