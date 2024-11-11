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

    private void OnButtonPressed()
    {
        // Change to game scene
        if (GetTree() != null)
        {
            GetTree().ChangeSceneToFile("res://main.tscn");

            string PlayerName = _nameInput.Text;
		
            SaveTextToFile(PlayerName);
		
            GD.Print("Player Name: " + PlayerName);
            
        }
    }

    private void SaveTextToFile(string PlayerName)
    {
        if (_nameInput == null)
        {
            GD.PrintErr("No Player Name Entered");
            return;
        }

        // Convert `res://` to a full file path
        string fullPath = ProjectSettings.GlobalizePath(_filePath);

        // Ensure directory exists
        string directoryPath = Path.GetDirectoryName(fullPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            GD.Print("Created directory: " + directoryPath);
        }

        // Write to the file
        File.WriteAllText(fullPath, PlayerName);
        GD.Print("Saved player name to: " + fullPath);
    }
}