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
	
	private Dictionary<Vector2I, Node2D> _cells = new();
	
	private Vector2I _highlightedCell = Vector2I.Zero;
	
	private Rect2 _cellOutline = new(0, 0, 64, 64);

	// Constructor.
	public Grid()
	{
		// Construct the grid by pre-allocating cells with null values.
		foreach (int x in Enumerable.Range(0, Width))
		{
			foreach (int y in Enumerable.Range(0, Height))
			{
				Vector2I coords = new(x, y);
				_cells[coords] = null;
				
				if (DebugMode)
				{
					// Debugging: Show grid lines.
					ReferenceRect rect = new();
					rect.Position = GridToWorld(new Vector2I(x, y));
					rect.Size = new Vector2I(CellSize, CellSize);
					rect.EditorOnly = false;
					AddChild(rect);
					
					// Debugging: Show labels.
					Label label = new();
					label.Position = GridToWorld(new Vector2I(x, y));
					label.Text = new Vector2I(x, y).ToString();
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
			Vector2I coords = WorldToGrid(motion.Position);
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

	public void SpawnPlayer(Vector2I cell)
	{
		if (IsOccupied(cell))
		{
			GD.Print("Cell already occupied! Not spawning player.");
			return;
		}

		PackedScene scn = ResourceLoader.Load<PackedScene>("res://Scenes/Player.tscn");
		Node2D player = (Node2D)scn.Instantiate();
		player.Position = new Vector2I(
			cell.X * CellSize + (CellSize / 2),
			cell.Y * CellSize + (CellSize / 2)
		);
		_cells[cell] = player;
		AddChild(player);
	}

	public void SpawnEnemy(Vector2I cell)
	{
		if (IsOccupied(cell))
		{
			GD.Print("Cell already occupied! Not spawning enemy.");
			return;
		}
		
		PackedScene scn = ResourceLoader.Load<PackedScene>("res://Scenes/Enemy.tscn");
		Node2D spawnedEnemy = (Node2D)scn.Instantiate();
		spawnedEnemy.Position = new Vector2I(
			cell.X * CellSize + (CellSize / 2),
			cell.Y * CellSize + (CellSize / 2)
		);
		_cells[cell] = spawnedEnemy;
		AddChild(spawnedEnemy);
	}

	public bool IsOccupied(Vector2I cell)
	{
		return _cells[cell] != null;
	}
	
	public Vector2 GridToWorld(Vector2I position)
	{
		return position * CellSize;
	}
	
	public Vector2I WorldToGrid(Vector2 position)
	{
		Vector2 converted = (position / CellSize).Floor();
		return new Vector2I((int)converted.X, (int)converted.Y);
	}
}
