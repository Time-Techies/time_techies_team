using Godot;
using System;
using TimeTechiesGame.scripts;

public partial class accessPoint : Area2D
{
    [Export] public string destination_level_tag { get; set; } = "";
    [Export] public string destination_door_tag { get; set; } = "";
    [Export] public string spawn_direction = "up";

    public override void _Ready()
    {
        if (!IsConnected("body_entered", new Callable(this, "_on_body_entered")))
        {
            Connect("body_entered", new Callable(this, "_on_body_entered"));
        }
    }

    private void _on_body_entered(Node body)
    {
        if (body is Player)
        {
            // Defer the scene change to the next frame
            CallDeferred("_change_level");
        }
        
    }

    private async void _change_level()
    {
        var manager = GetNode<LevelManager>("/root/LevelManager");
        if (manager != null)
        {
            await manager.go_to_level(destination_level_tag, destination_door_tag);
        }
    }
}