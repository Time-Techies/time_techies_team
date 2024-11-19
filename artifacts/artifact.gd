extends Area2D

func _on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Echo"):
		get_tree().change_scene_to_file("res://levels/medieval/medieval.tscn")
		#if get_tree_string() == "res://levels/medieval/medieval.tscn":
			#get_tree().change_scene_to_file("res://game.tscn")
		#elif get_tree_string() == "res://game.tscn":
			#
