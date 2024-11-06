using Godot;
using System;
using System.Collections.Generic;

public partial class BackgroundScene : Node2D
{
	[Export]
	public float ScrollSpeed = 100.0f;
	[Export] 
	 public Texture2D BackgroundTexture;
	private float _backgroundWidth;
	
	private List<Sprite2D> _backgrounds = new List<Sprite2D>();
	public override void _Ready()
	{
		_backgrounds.Add(GetNode<Sprite2D>("Background1"));
		_backgrounds.Add(GetNode<Sprite2D>("Background2"));

		foreach (var background in _backgrounds)
		{
			background.Texture = BackgroundTexture;
		}
		_backgroundWidth = _backgrounds[0].Texture.GetWidth();
		_backgrounds[1].Position = new Vector2(_backgroundWidth, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// starting point of sprite
		Vector2 scrollOffset = new Vector2(ScrollSpeed * (float)delta, 0);
		
		// loops through backgrounds 
		foreach (var background in _backgrounds)
		{
			background.Position -= scrollOffset;
		}
		
		for (int i = 0; i < _backgrounds.Count; i++)
		{
			if (_backgrounds[i].Position.X <= -_backgroundWidth)
			{
				// looping to find the second background's position to start the loop over
				int secondBackground = (i + 1) % _backgrounds.Count;
				_backgrounds[i].Position = new Vector2(_backgrounds[secondBackground].Position.X + _backgroundWidth, _backgrounds[i].Position.Y);
			}
		}

	}
}
