using Godot;
using System;

public partial class Door : Area2D
{

	[Export]
	public string DestinationLevel { get; set; }
	
	[Export]
	public string DestinationDirection { get; set; }
	
	private Node2D _spawn;

	public override void _Ready()
	{
		_spawn = GetNode<Node2D>("Spawn");
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is CharacterBody2D player)
		{
			if (player is Character)
				{
				string last_dir = player.getLastDirection();
				SceneManager.ChangeScene(DestinationLevel, last_dir);
				
				
				GD.Print("Leaving Door to" + last_dir);
				player.setLastDoor(DestinationDirection);
				}
		}
	}

}
