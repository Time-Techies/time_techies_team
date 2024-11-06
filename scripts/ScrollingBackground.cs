// using Godot;
//
// namespace TimeTechiesGame.scripts;
//
// public partial class ScrollingBackground : Node2D
// {
// 	// Reference to the two background sprites
// 	private Sprite _background1;
// 	private Sprite _background2;
//  
// 	// Speed of the scrolling background
// 	[Export]
// 	public float ScrollSpeed = 100f;
//  
// 	public override void _Ready()
// 	{
// 		// Initialize background sprites
// 		_background1 = GetNode<Sprite>("Background1");
// 		_background2 = GetNode<Sprite>("Background2");
//  
// 		// Position the second background next to the first
// 		_background2.Position = new Vector2(_background1.Texture.GetWidth(), 0);
// 	}
//  
// 	public override void _Process(float delta)
// 	{
// 		// Move both backgrounds to the left by the scroll speed
// 		_background1.Position += new Vector2(-ScrollSpeed * delta, 0);
// 		_background2.Position += new Vector2(-ScrollSpeed * delta, 0);
//  
// 		// Check if backgrounds have moved completely off screen
// 		if (_background1.Position.x <= -_background1.Texture.GetWidth())
// 		{
// 			// Reset the position to the end of the other background
// 			_background1.Position = _background2.Position + new Vector2(_background2.Texture.GetWidth(), 0);
// 		}
// 		if (_background2.Position.x <= -_background2.Texture.GetWidth())
// 		{
// 			// Reset the position to the end of the other background
// 			_background2.Position = _background1.Position + new Vector2(_background1.Texture.GetWidth(), 0);
// 		}
// 	}
// }