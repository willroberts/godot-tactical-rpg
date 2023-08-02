using Godot;
using System;

public partial class Level1 : Node
{
	public override void _Ready()
	{
		// Add collision metadata.
		// TBD.

		// Spawn the player.
		// TBD.

		// Add enemies.
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(8, 6));
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(8, 15));
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(2, 17));
	}

	public override void _Process(double delta) {}
}
