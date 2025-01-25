using Godot;
using System;

[GlobalClass]
public partial class VelocityComponent : Node {
	[Export] public CharacterBody2D body;
	public Vector2 Velocity { get; set; }
	public override void _Process(double delta) {
		body.Velocity = Velocity;
		body.MoveAndSlide();
	}	
}
