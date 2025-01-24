using Godot;
using System;

[GlobalClass]
public partial class Hurtbox : Area2D {
	[Signal] public delegate void HitReceivedEventHandler(Hitbox hitbox);

	public void OnHit(Hitbox hitbox) {
		EmitSignal(SignalName.HitReceived, hitbox);
	}
}
