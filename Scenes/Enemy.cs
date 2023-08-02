using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	public int TileSize = 64;
	public int OffsetSize = 32;
	//private Vector2 currentPosition = new Vector2(5, 2);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//double halfHeight = TileSize / 2;
		//Position = (currentPosition * TileSize) + new Vector2(OffsetSize, OffsetSize);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}
}
