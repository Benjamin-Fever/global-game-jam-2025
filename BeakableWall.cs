using Godot;
using System;

public partial class BreakableWall : Door
{

	private bool broken;

	 private StaticBody2D staticBody;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		staticBody = GetNode<StaticBody2D>("StaticBody2D");
        BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void OnBodyEntered(Node2D body){
		BreakWall(body);
		if(broken){
			base.OnBodyEntered(body);
		}
	}

	  private void ToggleCollision(bool locked)
    {
        GD.Print("ToggleCollision:" + locked);
        staticBody.GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", !locked);
	}

	private void BreakWall(Node2D body){
		if (body is CharacterBody2D player)
		{
			var movementStateMachine = player.GetNode<StateMachine>("MovementStateMachine");
			var dashingState = movementStateMachine.GetNode<DashState>("DashState");

			if(dashingState.IsActive && dashingState.shielded){
				//wall breaks animation or something
				broken = true;
				ToggleCollision(false);
				//toggle sprite
				base.OnBodyEntered(body);
		}
	}
}
