using Godot;

[GlobalClass]
public partial class SceneManager : Node {
	public static SceneManager instance;
	private Node2D _currentScene;


	public override void _EnterTree() {
		instance = this;
	}

	public override void _Ready() {
		_currentScene = GetChildOrNull<Node2D>(0);
	}

	public override void _Process(double delta) {

	}

	public static void ChangeScene(string scenePath) {
		PackedScene scene = GD.Load<PackedScene>(scenePath);
		if (scene == null) {
			GD.PrintErr("Scene not found: " + scenePath);
			return;
		}
		ChangeScene(scene);
	}

	public static void ChangeScene(PackedScene scene) {
		ChangeScene(scene.Instantiate<Node2D>());
	}

	public static void ChangeScene(Node2D scene) {
		instance._currentScene.QueueFree();
		instance._currentScene = scene;
		instance.AddChild(scene);
	}

	public static void CloseGame() {
		instance.GetTree().Quit();
	}
}