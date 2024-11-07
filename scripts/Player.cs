using System.Text.RegularExpressions;
using Godot;

namespace TimeTechiesGame.scripts;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 300.0f;
	
	[Export]
	public float JumpVelocity = -400.0f;
	
	[Export] public float Gravity = 1000.0f;
	
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	// TODO At end add light pulsing during movement and idle.

	public override void _Process(double delta)
	{
		var direction = Vector2.Zero;
		
		if (Input.IsActionPressed("ui_right"))
		{
			// IF delta/speed > x do running
			direction.X += 1;
			_animatedSprite.Play("walk-right");
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1;
			_animatedSprite.Play("walk-left");
		}
		else
		{
			_animatedSprite.Play("idle");
		}
	}

	public override void _PhysicsProcess(double delta)
	{

		// Add the gravity.
		if (!IsOnFloor())
		{
			Vector2 gravity = new Vector2(0, Gravity * (float)delta);
			Velocity += gravity;
		}

		// Handle Jump.
		var velocity = new Vector2(Velocity.X, Velocity.Y);
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		var direction = Input.GetAxis("ui_left", "ui_right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}