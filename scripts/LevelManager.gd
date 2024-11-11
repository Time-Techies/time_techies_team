extends Node

@onready var first_scene = preload("res://game.tscn")
@onready var second_scene = preload("res://levels/medieval/medieval.tscn")
@onready var player_scene = preload("res://echo/echo.tscn")

signal on_trigger_player_spawn(position: Vector2, direction: String)

var spawn_door_tag: String

func go_to_level(level_tag: String, destination_tag: String):
	var scene_to_load: PackedScene = null

	# Select the scene based on level_tag
	match level_tag:
		"L":
			scene_to_load = first_scene
		"R":
			scene_to_load = second_scene

	if scene_to_load != null:
		spawn_door_tag = destination_tag
		get_tree().change_scene_to_packed(scene_to_load)

		# Wait for one frame to ensure the scene has loaded
		await get_tree().process_frame

		# Get the current scene
		var current_scene = get_tree().current_scene

		# Find the spawn point in the destination access point
		var spawn_point = current_scene.get_node_or_null("AccessPoint_%s/Spawn" % destination_tag)

		if spawn_point != null:
			# Instance the player
			var player = player_scene.instantiate()
			current_scene.add_child(player)
			player.global_position = spawn_point.global_position

			# Setup camera if needed
			var camera = player.get_node_or_null("Camera2D") as Camera2D
			if camera != null:
				camera.make_current()

func trigger_player_spawn(position: Vector2, direction: String):
	emit_signal("on_trigger_player_spawn", position, direction)
