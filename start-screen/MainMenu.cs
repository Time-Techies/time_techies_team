using Godot;
using System;
using System.IO;
using FileAccess = Godot.FileAccess;

public partial class MainMenu : Control
{

	private LineEdit _nameInput;
	private TextureButton _startButton;

	private string _filePath = "res://start-screen/player-name-data.txt";
	
	public override void _Ready()
	{
		_nameInput = GetNode<LineEdit>("LineEdit");
		_startButton = GetNode<TextureButton>("Start");

		_startButton.Pressed += OnButtonPressed;
	}
	public override void _Process(double delta)
	{
	}

	private void OnButtonPressed()
	{
		// Change to game scene
		GetTree().ChangeSceneToFile("res://main.tscn");

		string PlayerName = _nameInput.Text;
		
		SaveTextToFile(PlayerName);
		
		GD.Print("Player Name: " + PlayerName);
	}

	private void SaveTextToFile(string PlayerName)
	{
		if (_nameInput == null)
		{
			GD.PrintErr("No Player Name Entered");
			return;
		}
		File.WriteAllText(_filePath, PlayerName);
	}
}

