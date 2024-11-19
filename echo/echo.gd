extends CharacterBody2D

@export var speed: float = 300.0
@export var jump_velocity: float = -400.0
@export var gravity: float = 1000.0

# Store the AnimatedSprite2D node
@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D

func _ready():
	# Verify that the AnimatedSprite2D node exists
	print(Echo.get_name())
	if !animated_sprite:
		push_error("AnimatedSprite2D node not found!")
		return
		
func _on_area_entered(body):
	if body.is_in_group("Artifact"):
		# Collision detected!
		print("Collision detected with Artifact")

func _process(delta):
	# Make sure animated_sprite exists before trying to play animations
	if !animated_sprite:
		return
		
	# Handle animation based on movement and jumping states
	if (Input.is_action_pressed("ui_right") or Input.is_action_pressed("ui_left")) and is_on_floor():
		if Input.is_action_pressed("ui_left"):
			animated_sprite.play("walk-left")
		else:
			animated_sprite.play("walk-right")
	elif !is_on_floor():
		if Input.is_action_pressed("ui_left"):
			animated_sprite.play("jump-left")
		else:
			animated_sprite.play("jump-default")
	elif is_on_floor():
		animated_sprite.play("idle")

func _physics_process(delta):
	# Apply gravity when not on the floor
	if !is_on_floor():
		velocity.y += gravity * delta

	# Changed back to ui_accept for spacebar
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = jump_velocity

	# Get input direction and apply movement
	var direction = Input.get_axis("ui_left", "ui_right")
	if direction != 0:
		velocity.x = direction * speed
	else:
		velocity.x = 0

	move_and_slide()


func _on_artifact_body_entered(body: Node2D) -> void:
	if body.is_in_group("Artifact"):
		# Collision detected!
		print("Collision detected with Artifact") # Replace with function body.
