using Godot;
using System;

public partial class DefaultState : State {
    public override void Enter() {
    }

    public override void Update(double delta) {
        var character = GetParent<StateMachine>().GetParent<Character>();
        var bubbleStateMachine = character.GetNode<StateMachine>("BubbleStateMachine");

        //check for cooldown on reflecting state
        var reflectingState = bubbleStateMachine.GetNode<ReflectingState>("ReflectingState");


        //block
        if (Input.IsActionJustPressed("block") && character.bubbleBlock > 0) {
            ChangeState("BlockingState");
        }

        //reflect
        if (Input.IsActionJustPressed("reflect") && character.bubbleBlock > 0) {
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