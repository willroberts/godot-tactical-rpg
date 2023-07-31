using Godot;
using System;

public partial class Player : Area2D
{
	[Signal]
	public delegate void HitEventHandler();

	[Export] // Same as "EditAnywhere" in Unreal Engine.
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

	public Vector2 ScreenSize; // Size of the game window.
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Player needs access to screen size for some reason? Maybe bounds checking.
		ScreenSize = GetViewportRect().Size;
		
		// Hide the character initially.
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Calculate movement vector.
		var velocity = Vector2.Zero; // The player's movement vector.
		if (Input.IsActionPressed("move_right")) { velocity.X += 1; }
		if (Input.IsActionPressed("move_left")) { velocity.X -= 1; }
		if (Input.IsActionPressed("move_down")) { velocity.Y += 1; }
		if (Input.IsActionPressed("move_up")) { velocity.Y -= 1; }

		// Configure animations.
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipV = false;
			// See the note below about boolean assignment.
			animatedSprite2D.FlipH = velocity.X < 0;
		}
		else if (velocity.Y != 0)
		{
			animatedSprite2D.Animation = "up";
			animatedSprite2D.FlipV = velocity.Y > 0;
		}

		// Play animations.
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else { animatedSprite2D.Stop(); }
		
		// Move the character.
		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}

	private void OnBodyEntered(Node2D body)
	{
		Hide(); // Player disappears after being hit.
		EmitSignal(SignalName.Hit);
		// Must be deferred as we can't change physics properties on a physics callback.
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}
	
	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

}
