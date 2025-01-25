using Godot;
using Godot.Collections;

[GlobalClass]
public partial class SceneManager : Node {
	public static SceneManager instance;
	public static Scene2D currentScene;


	public override void _EnterTree() {
		instance = this;
	}

	public override void _Ready() {
		currentScene = GetChildOrNull<Scene2D>(0);
	}

	public override void _Process(double delta) {

	}

	public static void ChangeScene(string scenePath, string direction) {
		PackedScene scene = GD.Load<PackedScene>(scenePath);
		if (scene == null) {
			GD.PrintErr("Scene not found: " + scenePath);
			return;
		}
		ChangeScene(scene, direction);
	}

	public static void ChangeScene(PackedScene scene, string direction) {
		ChangeScene(scene.Instantiate<Scene2D>(), direction);
	}

	public static void ChangeScene(Scene2D scene, string direction) {
		currentScene.Save();
		currentScene.QueueFree();
		currentScene = scene;
		instance.AddChild(scene);
		scene.Load(direction);
	}

	public static void CloseGame() {
		instance.GetTree().Quit();
	}

	public static Array<Vector2> GetPathToPoint(Vector2 start, Vector2 end) {
		GD.Print("current scene: ", currentScene);
		return currentScene?.GetPathToPoint(start, end);
	}
}
