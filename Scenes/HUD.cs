using Godot;
using System;

public partial class HUD : CanvasLayer
{
	private readonly Resource _cursorDefault = GD.Load("res://Assets/Sprites/Cursor/cursor.png");
	private readonly Resource _cursorClick = GD.Load("res://Assets/Sprites/Cursor/cursor_down.png");

	public override void _Ready() {}
	
	public override void _Input(InputEvent @event)
	{
		// Handle mouse cursor click animation.
		if (@event is InputEventMouseButton btn && btn.ButtonIndex == MouseButton.Left)
		{
			if (btn.Pressed) { Input.SetCustomMouseCursor(_cursorClick); }
			else { Input.SetCustomMouseCursor(_cursorDefault); }
		}

		// Handle unit selection. Should this be in a Unit class?
	}
}
