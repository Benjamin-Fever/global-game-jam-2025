using Godot;
using Godot.Collections;
using System;

public partial class ChasePlayerState : State {
	Character player;
	CharacterBody2D body;
	[Export] public float ChaseSpeed = 100;

    public override void _Ready() {
        player = GetTree().Root.GetNode<Character>("Main/Player");
		body = GetParent().GetParent<CharacterBody2D>();
    }


    public override void Update(double delta) {
		Vector2 targetPos = player.GlobalPosition;
		Array<Vector2> path = SceneManager.GetPathToPoint(body.GlobalPosition, targetPos);
		if (path.Count == 0) {
			ChangeState("IdleEnemyState");
			return;
		}
		path.RemoveAt(0);
		Vector2 direction = body.GlobalPosition.DirectionTo(path[0]);
		if (body.GlobalPosition.DistanceTo(path[0]) < 3) {
			body.GlobalPosition = path[0];
			path.RemoveAt(0);
		}
		body.Velocity = direction.Normalized() * ChaseSpeed;
		body.MoveAndSlide();
    }
}
