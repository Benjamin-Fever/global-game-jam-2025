using Godot;
using System;

public partial class DefaultState : State {
    public override void Enter() {
    }

    public override void Update(double delta) {
        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        var bubbleStateMachine = character.GetNode<StateMachine>("BubbleStateMachine");

        //check for cooldown on reflecting state
        var reflectingState = bubbleStateMachine.GetNode<ReflectingState>("ReflectingState");


        //block
        if (Input.IsActionJustPressed("block")) {
            ChangeState("BlockingState");
        }

        //reflect
        if (Input.IsActionJustPressed("reflect")) {
            if (reflectingState.IsActive || reflectingState.IsOnCooldown) {
                return;
            }
            else{
                ChangeState("ReflectingState");
            }   
        }
    }


    public override void Exit() {
    }
}