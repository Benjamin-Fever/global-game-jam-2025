using Godot;
using System;

public partial class Character : CharacterBody2D {
    private StateMachine MovingStateMachine;
    private StateMachine BubbleStateMachine;

    public override void _Ready() {
        MovingStateMachine = GetNode<StateMachine>("MovingStateMachine");
        BubbleStateMachine = GetNode<StateMachine>("BubbleStateMachine");

        MovingStateMachine.ChangeState("IdleState");
        BubbleStateMachine.ChangeState("DefaultState");
    }

    public override void _Process(double delta) {
        
    }
}