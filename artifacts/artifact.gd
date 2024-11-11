extends Area2D

func _on_body_entered(body):
	if body.is_in_group("Echo"):
		body.set_position($DestinationPoint.global_position)
