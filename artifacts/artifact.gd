extends Area2D

func _on_body_entered(body):
	if body.get_name() == "Echo":
		get_tree().change_scene_to_file("res://levels/medieval/medieval.tscn")
