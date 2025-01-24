using Godot;
using System;

public partial class DefaultState : State {
    public override void Enter() {
        GD.Print("Entering Default Bubble State (Vulnerable)");
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
                GD.Print("Cannot block while Reflecting Shield is active or on cooldown");
                return;
            }
            else{
                ChangeState("ReflectingState");
            }   
        }
    }


    public override void Exit() {
        GD.Print("Exiting Default Bubble State");
    }
}