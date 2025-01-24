using Godot;
using System;

public partial class Character : CharacterBody2D {
    private StateMachine MovingStateMachine;
    private StateMachine BubbleStateMachine;

    public override void _Ready() {
        MovingStateMachine = GetNode<StateMachine>("MovingStateMachine");
        BubbleStateMachine = GetNode<StateMachine>("BubbleStateMachine");

        // Initialize states
        MovingStateMachine.ChangeState("IdleState");
        BubbleStateMachine.ChangeState("DefaultState");
    }

    public override void _Process(double delta) {
        // Handle blocking input
        if (Input.IsActionJustPressed("block")) {
            BubbleStateMachine.ChangeState("BlockingState");
        }
    }
}