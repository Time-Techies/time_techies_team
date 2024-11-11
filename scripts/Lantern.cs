using Godot;

namespace TimeTechiesGame.scripts;

public partial class Lantern : Node
{
	// Called when the node enters the scene tree for the first time.
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("LanternSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_animatedSprite.Play("default");
	}
}