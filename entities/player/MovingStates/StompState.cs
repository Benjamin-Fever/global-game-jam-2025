using Godot;
using System;

public partial class StompState : State {
    private const float StompDuration = 1f;
    private float stompTime;

    public override void Enter() {
        GD.Print("Entering Stomp State");
        stompTime = 0;

        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");

        if (bubbleStateMachine?.currentState.Name == "BlockingState") {
            GD.Print("Creating Shockwave (Shielded Stomp)");
            
            //DO SHOCKWAVE HERE

            GD.Print("Shockwave created at position: " + character.Position);
        } else {
            GD.Print("Performing Simple Stomp");
            
            //GROUND STOMP HERE
        }
    }

    public override void Update(double delta) {
        stompTime += (float)delta;

        if (stompTime >= StompDuration) {
            ChangeState("IdleState");
        }
    }

    public override void Exit() {
        GD.Print("Exiting Stomp State");
    }
}