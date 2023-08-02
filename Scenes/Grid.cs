using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class Grid : Node2D
{
	[Export]
	public int Width = 12;
	
	[Export]
	public int Height = 20;
	
	[Export]
	public int CellSize = 64;
	
	[Export]
	public bool DebugMode = true;
	
	private Dictionary Cells = new Godot.Collections.Dictionary();

	// Constructor.
	public Grid()
	{
		foreach (int x in Enumerable.Range(0, Width))
		{
			foreach (int y in Enumerable.Range(0, Height))
			{
				Vector2 coords = new Vector2(x, y);
				Cells[coords] = new Godot.Collections.Dictionary();
				
				if (DebugMode)
				{
					//GD.Print("Coords:", coords);

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
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SpawnEnemy(Vector2 Position)
	{
		Dictionary ExistingContents = (Dictionary)Cells[Position];
		if (ExistingContents.Count() != 0)
		{
			GD.Print("Cell already occupied! Not spawning enemy.");
			GD.Print("Occupant:", ExistingContents);
			return;
		}
		
		var scn = ResourceLoader.Load<PackedScene>("res://Scenes/Enemies/Enemy.tscn");
		var spawnedEnemy = scn.Instantiate();
		AddChild(spawnedEnemy);
	}
	
	public Vector2 GridToWorld(Vector2 Position)
	{
		return Position * CellSize;
	}
	
	//public Vector2 WorldToGrid(Vector2 Position)
	//{
	//	return Math.Floor(Position / CellSize);
	//}
}
