using Godot;
using System;

public partial class ParallaxBackgroundControl : ParallaxBackground
{
	[Export] public Texture2D BackgroundTexture { get; set; }
	[Export] public Texture2D OtherBackgroundTexture { get; set; }

	[Export] public float ParallaxScroll = 0.5f;
	[Export] public float ParallaxSpeed2 = 0.25f;
	
	private ParallaxLayer _firstLayer;
	private ParallaxLayer _secondLayer;
	
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_firstLayer = GetNode<ParallaxLayer>("ParallaxLayer");
		_secondLayer = GetNode<ParallaxLayer>("ParallaxLayer2");
		
		var firstSpriteLayer = _firstLayer.GetNode<Sprite2D>("Sprite2D");
		firstSpriteLayer.Texture = BackgroundTexture;
		
		var secondSpriteLayer = _secondLayer.GetNode<Sprite2D>("Sprite2D");
		secondSpriteLayer.Texture = OtherBackgroundTexture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_firstLayer.MotionOffset -= new Vector2(ParallaxScroll * (float)delta, 0);
		_secondLayer.MotionOffset -= new Vector2(ParallaxScroll * (float)delta, 0);
	}

	
}
