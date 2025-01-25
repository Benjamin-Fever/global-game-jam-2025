using Godot;
using System;

[GlobalClass]
public partial class PlayerDetection : Area2D {
	[Signal] public delegate void PlayerDetectedEventHandler();

    public override void _Ready() {
        BodyEntered += (Node2D body) => {
			if (body is Character) {
				EmitSignal(SignalName.PlayerDetected);
			}
		};
    }

}
