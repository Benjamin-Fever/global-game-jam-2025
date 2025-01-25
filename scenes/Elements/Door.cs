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
		if (body is CharacterBody2D)
		{
			SceneManager.ChangeScene(DestinationLevel);
			GD.Print("Door");
		}
	}

}
