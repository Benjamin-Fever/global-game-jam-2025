using Godot;
using System;

[GlobalClass]
public partial class Character : CharacterBody2D {
    private StateMachine MovingStateMachine;
    private StateMachine BubbleStateMachine;
    [Export] private HealthComponent health;
    [Export] private int bubbleBlock = 5; 

    public override void _Ready() {
        MovingStateMachine = GetNode<StateMachine>("MovingStateMachine");
        BubbleStateMachine = GetNode<StateMachine>("BubbleStateMachine");

        MovingStateMachine.ChangeState("IdleState");
        BubbleStateMachine.ChangeState("DefaultState");
    }

    public override void _Process(double delta) {
        
    }


    public void OnOverlap(Area2D enemy){
        if (enemy is not Hitbox) return;
        if (BubbleStateMachine?.currentState.Name == "BlockingState" && bubbleBlock > 0) {
            bubbleBlock -= 1;
            //if(projectile){ return;}
            VelocityComponent velocityComponent = enemy.GetParent().GetNode<VelocityComponent>("VelocityComponent");
            GD.Print( velocityComponent.Velocity);
            velocityComponent.Velocity = -velocityComponent.Velocity.Normalized() * 800;
            GD.Print( velocityComponent.Velocity);
        }
        else{
            health.RemoveHealth(1);
        }
    }
    public void OnHit(Hitbox hitbox){
        if (BubbleStateMachine?.currentState.Name == "BlockingState" && bubbleBlock > 0) {
            bubbleBlock -= 1;
        }
        else{
            health.RemoveHealth(1);
        }
    }
}