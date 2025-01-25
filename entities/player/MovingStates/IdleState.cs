using Godot;
using System;

public partial class IdleState : State {

    public override void Update(double delta) {
        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");

       //dash
        if (Input.IsActionJustPressed("dash")) {
            ChangeState("DashState");
        }

        //stomp
        if (Input.IsActionJustPressed("stomp")) {
            ChangeState("StompState");
        }

        //move
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left") ||
            Input.IsActionPressed("move_up") || Input.IsActionPressed("move_down")) {
            ChangeState("MovingState");
        }
    }
}
