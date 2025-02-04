using Godot;
using System;

public partial class StompState : State {
    private const float StompDuration = 1f;
    private float stompTime;
    private const float PushDistance = 32f * 20f;
    [Export] VelocityComponent velocityComponent;

    public override void Enter() {
        stompTime = 0;
        
        var character = GetParent<StateMachine>().GetParent<Character>();
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");

        if (bubbleStateMachine?.currentState.Name == "BlockingState") {
            
            var shockwave = character.GetNodeOrNull<Area2D>("Shockwave");
            
            foreach (CharacterBody2D enemy in shockwave.GetOverlappingBodies()){

                if(enemy.IsInGroup("enemy")){
                    Vector2 locationEnemy = enemy.GlobalPosition;
                    Vector2 locationPlayer = character.GlobalPosition;
                    Vector2 direction = locationEnemy - locationPlayer;
                    Vector2 normalisedDirection = direction.Normalized();
                    
                    enemy.GetNode<VelocityComponent>("VelocityComponent").Velocity = normalisedDirection * PushDistance;
                    enemy.GetNode<StateMachine>("StateMachine").ChangeState("StunnedState");
                }

            }
            character.bubbleBlock = 0;

        } else {
            
            //GROUND STOMP HERE
        }
        velocityComponent.Velocity = Vector2.Zero;
    }

    public override void Update(double delta) {
        velocityComponent.Velocity = Vector2.Zero;
        stompTime += (float)delta;

        if (stompTime >= StompDuration) {
            ChangeState("IdleState");
        }
    }

    public override void Exit() {
    }
}