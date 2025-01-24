using Godot;
using System;

public partial class MovingState : State {
    private const float Speed = 200f; //movement speed

    public override void Enter() {
        GD.Print("Entering Moving State");
    }

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
        Vector2 input = Vector2.Zero;
        if (Input.IsActionPressed("move_right")) input.X += 1;
        if (Input.IsActionPressed("move_left")) input.X -= 1;
        if (Input.IsActionPressed("move_up")) input.Y -= 1;
        if (Input.IsActionPressed("move_down")) input.Y += 1;

        input = input.Normalized() * Speed;
        character.Velocity = input;
        character.MoveAndSlide();

        //idle
        if (input == Vector2.Zero) {
            ChangeState("IdleState");
        }
    }
}