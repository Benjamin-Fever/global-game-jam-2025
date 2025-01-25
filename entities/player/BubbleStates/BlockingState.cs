using Godot;
using System;

public partial class BlockingState : State {
    private Node2D bubble;

    public override void Enter() {

        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        bubble = character.GetNode<Node2D>("BlockingBubble");
        bubble.Visible = true;
    }

    public override void Update(double delta) {
        if (!Input.IsActionPressed("block")) {
            ChangeState("DefaultState");
        }
    }

    public override void Exit() {

        if (bubble != null) {
            bubble.Visible = false; //hide bubble
        }
    }
}