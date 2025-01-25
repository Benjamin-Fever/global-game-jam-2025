using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Character : CharacterBody2D {
	private StateMachine MovingStateMachine;
	private StateMachine BubbleStateMachine;
	[Export] private HealthComponent health;
	[Export] private int bubbleBlock = 5;

    readonly List<string> keys = new();

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
	public bool HasKey(string key){
		//Check if the key is in the list of keys
		return keys.Contains(key);
	}

	public void AddKey(string key){
		keys.Add(key);
	}
	public void RemoveKey(string key){
		keys.Remove(key);
	}

	public void printKeys(){
		foreach (var key in keys)
		{
			GD.Print(key);
		}
	}

}
