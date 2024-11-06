using Godot;

namespace TimeTechiesGame.scripts;

public partial class Player : CharacterBody2D
{
	[Export]
	public const float Speed = 300.0f;
	
	[Export]
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{

		// Add the gravity.
		if (!IsOnFloor())
		{
			var gravity = GetGravity() * (float)delta;
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