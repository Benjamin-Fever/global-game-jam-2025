using Godot;
using Godot.Collections;

public partial class BasicEnemy : CharacterBody2D {
	[Export] public float Speed = 100;

	private Array<Vector2> path = new Array<Vector2>();
	public override void _Input(InputEvent @event) {
		if (@event is InputEventMouseButton mouseEvent) {
			if (mouseEvent.ButtonIndex == MouseButton.Left) {
				Vector2 end = mouseEvent.Position;
				path = SceneManager.GetPathToPoint(GlobalPosition, end);
				GlobalPosition = path[0];
				path.RemoveAt(0);
			}
		}
	}

	public override void _Process(double delta) {
		if (path.Count == 0) {
			Velocity = Vector2.Zero; 
			return;
		}
		Vector2 direction = GlobalPosition.DirectionTo(path[0]);
		if (GlobalPosition.DistanceTo(path[0]) < 3) {
			GlobalPosition = path[0];
			path.RemoveAt(0);
		}
		Velocity = direction.Normalized() * Speed;
		MoveAndSlide();
		QueueRedraw();
	}

	public override void _Draw() {
		if (path.Count == 0) return;
		for (int i = 0; i < path.Count - 1; i++) {
			DrawLine(ToLocal(path[i]), ToLocal(path[i + 1]), new Color(1, 0, 0), 10);
		}
	}

}
