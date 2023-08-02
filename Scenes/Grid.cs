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
	public bool DebugMode = false;
	
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
	public override void _Ready() {}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}
	
	public override void _Input(InputEvent @event)
	{
		// Detect clicks in grid cells.
		if (@event is InputEventMouseButton btn &&
			btn.ButtonIndex == MouseButton.Left &&
			btn.Pressed)
		{
			GD.Print("Player clicked on cell ", WorldToGrid(btn.Position), " with coordinates ", btn.Position);
		}
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
		
		PackedScene scn = ResourceLoader.Load<PackedScene>("res://Scenes/Enemy.tscn");
		Node2D spawnedEnemy = (Node2D)scn.Instantiate();
		spawnedEnemy.Position = new Vector2(
			Position[0] * CellSize + 32,
			Position[1] * CellSize + 32
		);
		Cells[Position] = spawnedEnemy;
		AddChild(spawnedEnemy);
	}
	
	public Vector2 GridToWorld(Vector2 Position)
	{
		return Position * CellSize;
	}
	
	public Vector2 WorldToGrid(Vector2 Position)
	{
		return (Position / CellSize).Floor();
	}
}
