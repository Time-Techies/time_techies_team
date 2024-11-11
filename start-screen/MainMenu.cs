using Godot;
using System;
using System.IO;
using FileAccess = Godot.FileAccess;

public partial class MainMenu : Control
{
	private LineEdit _nameInput;
	private TextureButton _startButton;

	private string _filePath = "start-screen/names.txt";
	
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
		GetTree().ChangeSceneToFile("res://game.tscn");

		string PlayerName = _nameInput.Text;
		
		GD.Print("Button was pressed! Player Name: " + PlayerName);
		
		//Call function to save the name to file
		SaveTextToFile(PlayerName);
	}

	private void SaveTextToFile(string PlayerName)
	{
		// What to do if player does not enter name
		if (PlayerName == String.Empty)
		{
			GD.Print("No Player Name Entered");
			return;
		}
		GD.Print("Test printing woooooooooooo " + PlayerName);
		
		// Write PlayerName to "player-name-data.txt" file
		try
		{
			//File.WriteAllText(_filePath, PlayerName);
			using (StreamWriter writer = new StreamWriter(_filePath, append: true))
			{
				writer.WriteLine(PlayerName);
			}

			GD.Print($"Text saved to {_filePath}");
		}
		catch (Exception ex)
		{
			// Catch any exceptions and print the error
			GD.PrintErr($"Error saving file: {ex.Message}");
		}
		
		GD.Print("Saved Player Name: " + PlayerName);
	}
}
