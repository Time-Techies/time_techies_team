extends Node

var animated_sprite: AnimatedSprite2D

# Called when the node enters the scene tree for the first time.
func _ready():
	animated_sprite = $AnimatedSprite2D

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	animated_sprite.play("default")
