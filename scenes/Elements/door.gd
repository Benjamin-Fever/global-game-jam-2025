extends Area2D

class_name Door

@export var destination_level : String
@export var destination_direction : String


@onready var spwan = $Spawn

func _on_body_entered(body: Node2D) -> void:
	if body is CharacterBody2D:
		print("Door")
	pass # Replace with function body.
