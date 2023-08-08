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
	
	private Dictionary<Vector2, Node2D> _cells = new();
	
	private Vector2 _highlightedCell = Vector2.Zero;
	
	private Rect2 _cellOutline = new Rect2(0, 0, 64, 64);

	// Constructor.
	public Grid()
	{
		// Construct the grid by pre-allocating cells with null values.
		foreach (int x in Enumerable.Range(0, Width))
		{
			foreach (int y in Enumerable.Range(0, Height))
			{
				Vector2 coords = new(x, y);
				_cells[coords] = null;
				
				if (DebugMode)
				{
					// Debugging: Show grid lines.
					ReferenceRect rect = new();
					rect.Position = GridToWorld(new Vector2(x, y));
					rect.Size = new Vector2(CellSize, CellSize);
					rect.EditorOnly = false;
					AddChild(rect);
					
					// Debugging: Show labels.
					Label label = new();
					label.Position = GridToWorld(new Vector2(x, y));
					label.Text = new Vector2(x, y).ToString();
					AddChild(label);
				}
			}
		}
	}

	public override void _Ready() {}
	
	public override void _Input(InputEvent @event)
	{
		// Highlight current grid cell.
		if (@event is InputEventMouseMotion motion)
		{
			Vector2 coords = WorldToGrid(motion.Position);
			if (_highlightedCell != coords)
			{
				_highlightedCell = coords;
				_cellOutline.Position = GridToWorld(_highlightedCell);

				// FIXME: Drawing is only allowed in a _Draw() function.
				//DrawRect(CellOutline, Colors.AliceBlue, true, (float)2.0);
			}
		}

		// Detect clicks in grid cells.
		if (@event is InputEventMouseButton btn &&
			btn.ButtonIndex == MouseButton.Left &&
			btn.Pressed)
		{
			GD.Print("Player clicked on cell ", WorldToGrid(btn.Position));
		}
	}

	public void SpawnEnemy(Vector2 Position)
	{
		Node2D ExistingContents = _cells[Position];
		if (ExistingContents != null)
		{
			GD.Print("Cell already occupied! Not spawning enemy.");
			GD.Print("Occupant:", ExistingContents);
			return;
		}
		
		PackedScene scn = ResourceLoader.Load<PackedScene>("res://Scenes/Enemy.tscn");
		Node2D spawnedEnemy = (Node2D)scn.Instantiate();
		spawnedEnemy.Position = new Vector2(
			Position[0] * CellSize + (CellSize / 2),
			Position[1] * CellSize + (CellSize / 2)
		);
		_cells[Position] = spawnedEnemy;
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
