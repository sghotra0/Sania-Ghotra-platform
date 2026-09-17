using Godot;
using System;

public partial class Area2d : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
func _on_body_entered(body: Node2D) -> void:
	# Check if the entering body is in the "player" group
	if body.is_in_group("player"):
		print("Player entered the area!")
