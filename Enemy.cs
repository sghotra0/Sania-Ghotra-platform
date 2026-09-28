using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	public float Speed = 50.0f;
	public const float JumpVelocity = -400.0f;

	[Export] public RayCast2D GroundRight;
	[Export] public RayCast2D GroundLeft;

	public override void _Ready()
	{
		var velocity = Velocity;
		velocity.X = Speed;
		Velocity = velocity;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Speed > 0)
		{
			if (!GroundRight.IsColliding())
			{
				Speed = -1 * Speed;
			}
		}
		else
		{
			if (!GroundLeft.IsColliding())
			{
				Speed = -1 * Speed;
			}
		}		
		
		velocity.X = Speed;
		Velocity = velocity;
		MoveAndSlide();
	}


	public void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
