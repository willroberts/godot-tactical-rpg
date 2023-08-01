using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Unused.
	public const float Speed = 1.0f;
	public const float JumpVelocity = 0.0f;
	public float gravity = 0.0f;
	
	public int TileSize = 64;
	public int OffsetSize = 32;
	private Vector2 currentPosition = new Vector2(5, 2);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		double halfHeight = TileSize / 2;
		Position = (currentPosition * TileSize) + new Vector2(OffsetSize, OffsetSize);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
