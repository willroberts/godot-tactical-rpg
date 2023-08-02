using Godot;
using System;

public partial class Level1 : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(8, 6));
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(8, 15));
		GetNode<Grid>("Grid").SpawnEnemy(new Vector2(2, 17));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}
}
