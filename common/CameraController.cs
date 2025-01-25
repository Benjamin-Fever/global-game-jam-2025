using Godot;
using System;

public partial class CameraController : Camera2D {
	[Export] Node2D target;

    public override void _Process(double delta) {
        GlobalPosition = GlobalPosition.Lerp(target.GlobalPosition, 0.15f);
    }

}
