using Godot;
using System;

public partial class StunnedState : State {
	[Export] private float StunDuration = 2;
	[Export] private VelocityComponent velocityComponent;
	private float timer = 0;

    public override void Enter() {
		velocityComponent.Velocity = Vector2.Zero;
		timer = StunDuration;
    }

	public override void Update(double delta) {
		timer -= (float)delta;
		if (timer <= 0) {
			ChangeState("ChasePlayerState");
		}
	}

}	
