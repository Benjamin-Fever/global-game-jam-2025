using Godot;
using System;

public partial class DashState : State {
    private const float DashSpeed = 600f; //dash speed
    private const float DashDistance = 100f; //dash distance
    private Vector2 dashDirection;
    private float dashProgress;

    public override void Enter() {
        GD.Print("Entering Dash State");

        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");

        if (bubbleStateMachine?.currentState.Name == "BlockingState") {
            GD.Print("Performing Shielded Dash");

            //SHIELDED DASH HERE

        } else {
            GD.Print("Performing Regular Dash");

            //REGULAR DASH (code may not need anything here?)
        }

        //direction
        dashDirection = character.Velocity.Normalized();

        //default to right if not moving currently
        if (dashDirection == Vector2.Zero) {
            dashDirection = new Vector2(1, 0);
        }

        dashProgress = 0;
        character.Velocity = Vector2.Zero; //remove extra movement
    }

    public override void Update(double delta) {
        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();

        //do dash
        var dashStep = dashDirection * DashSpeed * (float)delta;
        character.Position += dashStep;
        dashProgress += dashStep.Length();

        //only finish if dash is complete
        if (dashProgress >= DashDistance) {
            ChangeState("IdleState");
        }
    }

    public override void Exit() {
        GD.Print("Exiting Dash State");
    }
}