using Godot;
using System;

[GlobalClass]
public partial class VelocityComponent : Node {
	[Export] public CharacterBody2D body;
	[Export] private float _drag = 40f;
	public Vector2 Velocity { get; set; }
	public override void _Process(double delta) {
		// Apply drag
		Velocity = Velocity.MoveToward(Vector2.Zero, _drag * (float)delta);
		body.Velocity = Velocity;
		body.MoveAndSlide();
	}	
}
