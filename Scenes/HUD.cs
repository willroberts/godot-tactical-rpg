using Godot;
using System;

public partial class HUD : CanvasLayer
{
	Resource CursorDefault = GD.Load("res://Assets/Sprites/Cursor/cursor.png");
	Resource CursorClick = GD.Load("res://Assets/Sprites/Cursor/cursor_down.png");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}
	
	public override void _Input(InputEvent @event)
	{
		// Handle mouse cursor click animation.
		if (@event is InputEventMouseButton btn &&
			btn.ButtonIndex == MouseButton.Left)
		{
			if (btn.Pressed) { Input.SetCustomMouseCursor(CursorClick); }
			else { Input.SetCustomMouseCursor(CursorDefault); }
		}
	}
}
