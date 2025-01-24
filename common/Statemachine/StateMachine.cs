using Godot;
using System;

[GlobalClass]
public partial class StateMachine : Node {
	[ExportGroup("Settings")]
	[Export] public State currentState;

	public void ChangeState(string stateName) {
		State newState = GetNodeOrNull<State>(stateName);
		if (newState == null) {
			GD.PrintErr("State not found: " + stateName);
			return;
		}
		ChangeState(newState);
	}

	public void ChangeState(State newState) {
		if (currentState == newState) return;
		if (!newState.CanChangeState()) return;
		
		currentState?.Exit();
		currentState = newState;
		currentState.Enter();
	}

	public override void _Ready() {
		currentState.Enter();
	}

	public override void _Process(double delta) {
		currentState.Update(delta);
	}
}
