using Godot;
using System;

public partial class Door : Area2D
{

	[Export]
	public string DestinationLevel { get; set; }
	
	[Export]
	public Vector2 DestinationVector { get; set; }

	public override void _Ready()
	{
		
	}

	private void _on_body_entered(Node2D body)
	{
		GD.Print("Door");
		if (body is Character player)
		{
			
			if (player is Character)
				{
				player.GlobalPosition = DestinationVector;
				}
				SceneManager.ChangeScene("res://scenes/Levels/"+DestinationLevel + ".tscn");
		}
	}

}
