using Godot;

namespace TimeTechiesGame.scripts;

public partial class world_audio : AudioStreamPlayer2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		if (GetTree().Root.HasNode("/root/WorldAudio"))
		{
			QueueFree();
		}
		else
		{
			GetTree().Root.AddChild(this);
			Name = "world_audio";
			Owner = null;
			SetProcess(false);
			if (!Playing)
			{
				Play();
			}

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}