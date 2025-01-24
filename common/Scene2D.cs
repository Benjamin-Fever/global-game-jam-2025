using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class Scene2D : Node2D {
    [Signal] public delegate void SceneLoadedEventHandler();
    [Export] public SceneData sceneData;
    [Export] private TileMapLayer mapLayer;

    private AStarGrid2D astar;

    public override void _Ready() {
        astar = new AStarGrid2D();
        astar.DefaultComputeHeuristic = AStarGrid2D.Heuristic.Manhattan;
        astar.DefaultEstimateHeuristic = AStarGrid2D.Heuristic.Manhattan;
        astar.DiagonalMode = AStarGrid2D.DiagonalModeEnum.OnlyIfNoObstacles;

        
        Vector2I tileLayerSize = mapLayer.GetUsedRect().End - mapLayer.GetUsedRect().Position;
        astar.CellSize = mapLayer.TileSet.TileSize;
        astar.Region = new Rect2I(Vector2I.Zero, tileLayerSize);
        astar.Update();

        for (int x = 0; x < tileLayerSize.X; x++) {
            for (int y = 0; y < tileLayerSize.Y; y++) {
                Vector2I tilePos = new Vector2I(x, y);
                if ((bool)mapLayer.GetCellTileData(tilePos).GetCustomData("SolidFlag")) {
                    astar.SetPointSolid(tilePos, true);
                }
            }
        }
        EmitSignal(SignalName.SceneLoaded);
    }

    public Vector2[] GetPathToPoint(Vector2 start, Vector2 end) {
        return astar.GetPointPath(mapLayer.LocalToMap(start), mapLayer.LocalToMap(end));
    }

    public void Save() {
        foreach (NodePath path in sceneData.data.Keys) {
            Node2D node = GetNodeOrNull<Node2D>(path);
            if (node == null) {
                GD.PrintErr("Node not found: " + path);
                continue;
            }

            Dictionary<string, Variant> nodeData = sceneData.data[path];
            foreach (string key in nodeData.Keys) {
                nodeData[key] = node.Get(key);
            }   
        }
    }

    public void Load() {
        foreach (NodePath path in sceneData.data.Keys) {
            Node2D node = GetNodeOrNull<Node2D>(path);
            if (node == null) {
                GD.PrintErr("Node not found: " + path);
                continue;
            }

            Dictionary<string, Variant> nodeData = sceneData.data[path];
            foreach (string key in nodeData.Keys) {
                node.Set(key, nodeData[key]);
            }   
        }
    }
}