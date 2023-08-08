using Godot;
using System;

public partial class Player : Node2D
{
	public int TileSize = 64;
	public int OffsetSize = 32;
	private Vector2I _currentPosition = new(5, 2);
	
	public override void _Ready()
	{
		// double halfHeight = TileSize / 2;
		Position = (_currentPosition * TileSize) + new Vector2I(OffsetSize, OffsetSize);
	}
}
