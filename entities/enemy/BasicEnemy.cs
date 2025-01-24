using Godot;
using Godot.Collections;

public partial class BasicEnemy : CharacterBody2D {
	[Export] public float Speed = 100;
	public override void _Ready() {
	}

	public override void _PhysicsProcess(double delta) {

	}
}
