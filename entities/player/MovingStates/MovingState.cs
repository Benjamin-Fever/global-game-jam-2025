using Godot;
using System;

public partial class MovingState : State {
    private const float Speed = 200f; //movement speed
    [Export] VelocityComponent velocityComponent;
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

        //movement
        Vector2 input = Input.GetVector("move_left", "move_right", "move_up", "move_down");

        velocityComponent.Velocity = input.Normalized() * Speed;

        //idle
        if (input == Vector2.Zero) {
            ChangeState("IdleState");
        }
    }
}