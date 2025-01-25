using Godot;
using System;

public partial class DashState : State {
    private const float DashSpeed = 400f; //dash speed
    private const float DashDistance = 128f; //dash distance
    private const float PushDistance = 64f; //pushing disntace
    private Vector2 dashDirection;
    private float dashProgress;
    private bool shielded = false;

    public override void Enter() {

        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");

        if (bubbleStateMachine?.currentState.Name == "BlockingState") {

            //SHIELDED DASH HERE
            shielded = true;

        } else {

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

    public void onCollide(Node2D enemy){
        if(shielded){
            if(enemy.IsInGroup("enemy")){
                //enemy.Velocity = dashDirection * PushDistance;
            }
        }
    }

    public override void Update(double delta) {
        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();

        //do dash
        var dashStep = dashDirection * DashSpeed * (float)delta;
        character.Position += dashStep;
        dashProgress += dashStep.Length();

        //only finish if dash is complete
        if (dashProgress >= DashDistance) {
            shielded = false;
            ChangeState("IdleState");
        }
    }

    public override void Exit() {
    }
}