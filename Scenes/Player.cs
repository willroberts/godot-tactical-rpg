using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int TileSize = 64;
	public int OffsetSize = 32;
	private Vector2 currentPosition = new Vector2(5, 2);
	
	public override void _Ready()
	{
		double halfHeight = TileSize / 2;
		Position = (currentPosition * TileSize) + new Vector2(OffsetSize, OffsetSize);
	}

	public override void _Process(double delta) {}
}
