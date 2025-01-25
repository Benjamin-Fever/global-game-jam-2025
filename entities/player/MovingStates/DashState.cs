using Godot;
using System;

public partial class DashState : State {
    [Export] private float DashDistance = 256f; //dash distance
    [Export] private float DashTime = 1.0f;
    private const float PushDistance = 64 * 20f; //pushing disntace
    private Vector2 dashDirection;
    private bool shielded = false;
    private Vector2 startPos;
    private Vector2 prevPos;
    private Vector2 velocityDirection;
    private Character character;

    [Export] VelocityComponent velocityComponent;

    public override void _Ready() {
        character = GetParent<StateMachine>().GetParent<Character>();
    }

    public override void Enter() {
        var bubbleStateMachine = character.GetNodeOrNull<StateMachine>("BubbleStateMachine");
        shielded = bubbleStateMachine?.currentState.Name == "BlockingState";
        if(shielded){character.bubbleBlock = 0;}
        
        dashDirection = character.Velocity.Normalized() == Vector2.Zero ?  velocityDirection : character.Velocity.Normalized();
        character.Velocity = Vector2.Zero;
        startPos = character.GlobalPosition;
    }

    public void OnCollide(Node2D enemy){
        if(shielded){
            if(enemy.IsInGroup("enemy")){
                enemy.GetNode<VelocityComponent>("VelocityComponent").Velocity = dashDirection * PushDistance;
            }
        }
    }

    public override void Update(double delta) {
        velocityComponent.Velocity =  dashDirection * (DashDistance / DashTime);

        if (startPos.DistanceTo(character.GlobalPosition) >= DashDistance || prevPos == character.GlobalPosition){
            shielded = false;
            ChangeState("IdleState");
            velocityComponent.Velocity = Vector2.Zero;
        }
        prevPos = character.GlobalPosition;
    }

    public override void _Process(double delta) {
        base._Process(delta);

        velocityDirection = character.Velocity.Normalized() == Vector2.Zero ? velocityDirection : character.Velocity.Normalized();
    }

    public override void Exit() {
    }
}