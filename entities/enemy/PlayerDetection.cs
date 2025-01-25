using Godot;
using System;

[GlobalClass]
public partial class PlayerDetection : Area2D {
	[Signal] public delegate void PlayerEnteredEventHandler();
	[Signal] public delegate void PlayerExitedEventHandler();

    public override void _Ready() {
        BodyEntered += (Node2D body) => {
			if (body is Character) {
				EmitSignal(SignalName.PlayerEntered);
			}
		};

		BodyExited += (Node2D body) => {
			if (body is Character) {
				EmitSignal(SignalName.PlayerExited);
			}
		};
    }

}
