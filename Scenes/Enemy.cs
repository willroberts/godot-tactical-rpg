using Godot;
using System;

public partial class Enemy : Node2D
{
	public int TileSize = 64;
	public int OffsetSize = 32;
	//private Vector2 _currentPosition = new Vector2(5, 2);
	
	public override void _Ready()
	{
		//double halfHeight = TileSize / 2;
		//Position = (_currentPosition * TileSize) + new Vector2(OffsetSize, OffsetSize);
	}
}
