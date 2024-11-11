extends Area2D

func _on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Echo"):
		body.set_position($DestinationPoint.global_position)
