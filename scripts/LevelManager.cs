using Godot;
using System.Threading.Tasks;

public partial class LevelManager : Node
{
    private PackedScene _firstScene = GD.Load<PackedScene>("res://main.tscn");
    private PackedScene _secondScene = GD.Load<PackedScene>("res://second_level.tscn");
    private PackedScene _playerScene = GD.Load<PackedScene>("res://echo.tscn");

    [Signal]
    public delegate void OnTriggerPlayerSpawnEventHandler(Vector2 position, string direction);

    private string _spawnDoorTag;

    public async Task go_to_level(string levelTag, string destinationTag)
    {
        PackedScene sceneToLoad = null;

        if (levelTag == "L")
        {
            sceneToLoad = _firstScene;
        } else if (levelTag == "R")
        {
            sceneToLoad = _secondScene;
        }
        else
        {
            sceneToLoad = _firstScene;
        }
        
        // switch (levelTag)
        // {
        //     case "L":
        //         sceneToLoad = _firstScene;
        //         break;
        //     case "R":
        //         sceneToLoad = _secondScene;
        //         break;
        // }
        //

        if (sceneToLoad != null)
        {
            _spawnDoorTag = destinationTag;
            GetTree().ChangeSceneToPacked(sceneToLoad);
            
            // Wait one frame for the scene to load
            await ToSignal(GetTree(), "process_frame");
            
            // Get the current scene
            var currentScene = GetTree().CurrentScene;
            
            // Find the spawn point in the destination access point
            var spawnPoint = currentScene.GetNode<Node2D>($"AccessPoint_{destinationTag}/Spawn");
            
            if (spawnPoint != null)
            {
                // Instance the player
                var player = _playerScene.Instantiate<Node2D>();
                currentScene.AddChild(player);
                player.GlobalPosition = spawnPoint.GlobalPosition;
                
                // Setup camera if needed
                var camera = player.GetNode<Camera2D>("Camera2D");
                if (camera != null)
                {
                    camera.MakeCurrent();
                }
            }
        }
    }
    

    public void TriggerPlayerSpawn(Vector2 position, string direction)
    {
        EmitSignal(nameof(OnTriggerPlayerSpawn), position, direction);
    }
}