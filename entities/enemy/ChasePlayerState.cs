using Godot;
using Godot.Collections;
using System;

public partial class ChasePlayerState : State {
	Character player;
	[Export] private float ChaseSpeed = 100;
	[Export] private VelocityComponent velocityComponent;
	private Array<Vector2> path = new Array<Vector2>();

    public override void _Ready() {
        player = GetTree().Root.GetNode<Character>("Main/Player");
    }


    public override void Update(double delta) {
		Vector2 targetPos = player.GlobalPosition;
		path = SceneManager.GetPathToPoint(velocityComponent.body.GlobalPosition, targetPos);
		if (path.Count == 0) {
			ChangeState("IdleEnemyState");
			return;
		}
		path.RemoveAt(0);
		Vector2 direction = velocityComponent.body.GlobalPosition.DirectionTo(path[0]);
		if (velocityComponent.body.GlobalPosition.DistanceTo(path[0]) < 3) {
			velocityComponent.body.GlobalPosition = path[0];
			velocityComponent.Velocity = Vector2.Zero;
			path.RemoveAt(0);
			return;
		}
		velocityComponent.Velocity = direction.Normalized() * ChaseSpeed * (float)delta;
    }



}
