using Godot;
using System;

public partial class character : Sprite2D
{
	[Signal]
	public delegate void HealthDepletedEventHandler();
	
	[Signal]
	public delegate void HealthChangedEventHandler(int oldValue, int newValue);
	
	private int _health = 3;
	private int _speed = 400;
	private float _angularSpeed = Mathf.Pi;

	// Constructor
	public character()
	{
		GD.Print("Created character.");
	}

	// Called when the node enters the scene tree for the first time.
	// "BeginPlay" in Unreal Engine.
	// public override void _Ready() {}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// "Tick" in Unreal Engine.
	public override void _Process(double delta)
	{
		// Rotate the pawn according to player input, checking input every tick.
		// Use _UnhandledInput() instead when handling periodic input.
		var direction = 0;
		if (Input.IsActionPressed("ui_left")) { direction = -1; }
		if (Input.IsActionPressed("ui_right")) { direction = 1; }
		Rotation += _angularSpeed * direction * (float)delta;

		// Move the pawn up according to its own orientation.
		var velocity = Vector2.Zero;
		if (Input.IsActionPressed("ui_up"))
		{
			velocity = Vector2.Up.Rotated(Rotation) * _speed;
		}
		Position += velocity * (float)delta;
	}

	private void OnButtonPressed()
	{
		// Toggle ticking.
		SetProcess(!IsProcessing());
	}
	
	public void TakeDamage(int amount)
	{
		int oldHealth = _health;
		_health -= amount;
		
		if (_health <= 0) { EmitSignal(SignalName.HealthDepleted); }
		EmitSignal(SignalName.HealthChanged, oldHealth, _health);
	}
}
