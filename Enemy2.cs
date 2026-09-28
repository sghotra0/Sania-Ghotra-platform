using Godot;
using System;

public partial class Enemy2 : Enemy
{
    public override void _PhysicsProcess(double delta)
    {
    public override void _PhysicsProcess(double delta)
        {
        Vector2 velocity = Velocity;
        @export var speed: float = 150.0

# Finds the player node in the scene tree
        @onready var player = get_tree().current_scene.find_child("Player")

        func _physics_process(_delta: float) -> void:
        if player:
# Get direction pointing toward the player
        var direction = global_position.direction_to(player.global_position)
		
# Set velocity and move
        velocity = direction * speed
        move_and_slide()
		
# Optional: Flip the sprite to face the player
        if direction.x < 0:
            $Sprite2D.flip_h = true
        elif direction.x > 0:
            $Sprite2D.flip_h = false
        