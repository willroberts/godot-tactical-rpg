using Godot;
using System;

public partial class npc : Sprite2D
{
	private int _speed = 400;
	private float _angularSpeed = Mathf.Pi;

	// Constructor
	public npc()
	{
		GD.Print("Created NPC.");
	}

	// Called when the node enters the scene tree for the first time.
	// "BeginPlay" in Unreal Engine.
	public override void _Ready()
	{
		var timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// "Tick" in Unreal Engine.
	public override void _Process(double delta)
	{
		Rotation += _angularSpeed * (float)delta;
		var velocity = Vector2.Up.Rotated(Rotation) * _speed;
		Position += velocity * (float)delta;
	}

	private void OnButtonPressed()
	{
		// Toggle ticking.
		SetProcess(!IsProcessing());
	}
	
	private void OnTimerTimeout()
	{
		// Toggle visibility status.
		Visible = !Visible;
	}
}
