
using Godot;
using System;

public partial class Breakable : Area2D
{

	[Export]
	public string DestinationLevel { get; set; }
	
	[Export]
	public Vector2 DestinationVector { get; set; }
	[Export]
	
	private Node2D spawn;
	[Export] public bool broken;
	

	public override void _Ready()
	{
		spawn = GetNode<Node2D>("Spawn");
		BodyEntered += OnBodyEntered;
		
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is CharacterBody2D player)
		{
			var movementStateMachine = player.GetNode<StateMachine>("MovementStateMachine");
			var dashingState = movementStateMachine.GetNode<DashState>("DashState");

			if(dashingState.IsActive && dashingState.shielded){
				//wall breaks animation or something
				if (player is Character)
					{
						player.GlobalPosition = DestinationVector;
					}
					SceneManager.ChangeScene("res://scenes/Levels/"+DestinationLevel + ".tscn");
			}
		}
	}

}
