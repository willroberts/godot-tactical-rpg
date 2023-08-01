using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class Grid : Node2D
{
	[Export]
	public int Width = 10;
	
	[Export]
	public int Height = 16;
	
	[Export]
	public int CellSize = 128;
	
	private Dictionary Cells = new Godot.Collections.Dictionary();

	// Constructor.
	public Grid()
	{
		foreach (int x in Enumerable.Range(0, Width))
		{
			foreach (int y in Enumerable.Range(0, Height))
			{
				Vector2 coords = new Vector2(x, y);
				GD.Print("Coords:", coords);
				Cells[coords] = 0;
				
				// Debugging: Show grid lines.
				ReferenceRect rect = new ReferenceRect();
				rect.Position = GridToWorld(new Vector2(x, y));
				rect.Size = new Vector2(CellSize, CellSize);
				rect.EditorOnly = false;
				AddChild(rect);
				
				// Debugging: Show labels.
				Label label = new Label();
				label.Position = GridToWorld(new Vector2(x, y));
				label.Text = new Vector2(x, y).ToString();
				AddChild(label);
			}
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public Vector2 GridToWorld(Vector2 pos)
	{
		return pos * CellSize;
	}
	
	//public Vector2 WorldToGrid(Vector2 pos)
	//{
	//	return Math.Floor(pos / CellSize);
	//}
}
