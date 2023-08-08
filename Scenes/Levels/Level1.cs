using Godot;
using System;

public partial class Level1 : Node
{
	//private Grid _grid = ResourceLoader.Load("res://Resources/Grid.tres") as Grid;
	private Grid _grid;

	public override void _Ready()
	{
		// Initialize components.
		_grid = GetNode<Grid>("Grid");

		// Spawn the player.
		// TBD.

		// Spawn enemies.
		_grid.SpawnEnemy(new Vector2I(8, 6));
		_grid.SpawnEnemy(new Vector2I(8, 15));
		_grid.SpawnEnemy(new Vector2I(2, 17));
	}
}
