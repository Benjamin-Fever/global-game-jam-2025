using Godot;
using Godot.Collections;

[GlobalClass]
public partial class GameMap : TileMapLayer {
	private AStarGrid2D astar;

	public override void _Ready() {
		astar = new AStarGrid2D();
		astar.DefaultComputeHeuristic = AStarGrid2D.Heuristic.Manhattan;
		astar.DefaultEstimateHeuristic = AStarGrid2D.Heuristic.Manhattan;
		astar.DiagonalMode = AStarGrid2D.DiagonalModeEnum.OnlyIfNoObstacles;
		astar.Offset = (Vector2)TileSet.TileSize / 2;

		
		Vector2I tileLayerSize = GetUsedRect().End - GetUsedRect().Position;
		astar.CellSize = TileSet.TileSize;
		astar.Region = new Rect2I(Vector2I.Zero, tileLayerSize);
		astar.Update();

		for (int x = 0; x < tileLayerSize.X; x++) {
			for (int y = 0; y < tileLayerSize.Y; y++) {
				Vector2I tilePos = new Vector2I(x, y);
				bool isTileSolid = (int)GetCellTileData(tilePos).GetCustomData("EventFlag") == 1;
				astar.SetPointSolid(tilePos, isTileSolid);
			}
		}
	}

	public Array<Vector2> GetPathToPoint(Vector2 start, Vector2 end) {
		Vector2I fromID = LocalToMap(start);
		Vector2I toID = LocalToMap(end);
		GD.Print(fromID, toID);
		Vector2[] path = astar.GetPointPath(fromID, toID);
		return new Array<Vector2>(path);
	}
}
