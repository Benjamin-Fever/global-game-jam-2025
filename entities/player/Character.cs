using Godot;
using System;

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

    public void OnHit(Hitbox hitbox){
        //if(hitbox.GetParent() == )
        if (BubbleStateMachine?.currentState.Name == "BlockingState" && bubbleBlock > 0) {
            bubbleBlock -= 1;
        }
        else{
            health.RemoveHealth(1);
        }
    }
}