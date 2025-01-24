using Godot;
using System;

[GlobalClass]
public abstract partial class State : Node {
	private StateMachine _stateMachine => GetParent<StateMachine>(); 
	
	protected void ChangeState(string stateName) {
		_stateMachine.ChangeState(stateName);
	}

	public virtual void Enter() { }
	public virtual void Update(double delta) { }
	public virtual void Exit() { }
	public virtual bool CanChangeState() { return true; }
}
