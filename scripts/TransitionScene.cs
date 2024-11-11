using Godot;

public partial class TransitionScene : CanvasLayer
{
    // Signal definition
    [Signal]
    public delegate void OnTransitionFinishedEventHandler();

    // Node references
    private ColorRect _colorRect;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        // Get node references
        _colorRect = GetNode<ColorRect>("ColorRect");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        // Hide ColorRect initially
        _colorRect.Visible = false;

        // Connect the animation finished signal
        _animationPlayer.AnimationFinished += OnAnimationFinished;
    }

    // Method to start the transition
    public void Transition()
    {
        _colorRect.Visible = true;
        _animationPlayer.Play("fade_to_black");
    }

    // Callback for when the animation finishes
    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "fade_to_black")
        {
            EmitSignal(nameof(OnTransitionFinished));
            _animationPlayer.Play("fade_to_normal");
        }
        else if (animName == "fade_to_normal")
        {
            _colorRect.Visible = false;
        }
    }
}