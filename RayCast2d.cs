using Godot;
using System;

public partial class RayCast2d : RayCast2D
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
func _physics_process(_delta: float) -> void:
	if laser_ray.is_colliding():
		# If it's an enemy then take action
		if collider.is_in_group("enemies"):
			print("Enemy found!")
	else:
		# The ray is shooting into empty space
		pass
