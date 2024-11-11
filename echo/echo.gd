extends CharacterBody2D

@export var speed: float = 300.0
@export var jump_velocity: float = -400.0
@export var gravity: float = 1000.0

var animated_sprite: AnimatedSprite2D

func _ready():
	animated_sprite = $AnimatedSprite2D

func _process(delta):
	# Handle animation based on movement and jumping states.
	if (Input.is_action_pressed("ui_right") or Input.is_action_pressed("ui_left")) and is_on_floor():
		if Input.is_action_pressed("ui_left"):
			animated_sprite.play("walk-left")
		else:
			animated_sprite.play("walk-right")
	elif Input.is_action_pressed("ui_accept") and not is_on_floor():
		if Input.is_action_pressed("ui_left"):
			animated_sprite.play("jump-left")
		else:
			animated_sprite.play("jump")
	elif is_on_floor():
		animated_sprite.play("idle")

func _physics_process(delta):
	# Apply gravity when not on the floor.
	if not is_on_floor():
		velocity.y += gravity * delta

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = jump_velocity

	# Get input direction and apply movement.
	var direction = Input.get_axis("ui_left", "ui_right")
	if direction != 0:
		velocity.x = direction * speed
	else:
		# Immediately stop horizontal velocity when there's no input.
		velocity.x = 0

	# Apply the velocity and move the character.
	move_and_slide()


func _on_artifact_body_entered(body: Node2D) -> void:
	pass # Replace with function body.
