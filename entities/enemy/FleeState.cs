using Godot;
using Godot.Collections;
using System;

public partial class FleeState : State {
	private Character player;
	private CharacterBody2D body;
	[Export] public float FleeSpeed = 100;
	[Export] private VelocityComponent velocityComponent;


	public override void _Ready() {
        player = GetTree().Root.GetNode<Character>("Main/Player");
		body = GetParent().GetParent<CharacterBody2D>();
	}

	public override void Update(double delta) {
		Vector2 targetPos = player.GlobalPosition;
		Vector2 direction = -body.GlobalPosition.DirectionTo(targetPos);
		velocityComponent.Velocity = direction.Normalized() * FleeSpeed * (float)delta;
	}

}
