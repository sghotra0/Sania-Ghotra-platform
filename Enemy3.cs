using Godot;
using System;

public partial class Enemy3 : CharacterBody2D
{
}
@export var speed: float = 120.0

    var player: Node2D = null

func _ready():
# Find the player using the group name
var players = get_tree().get_nodes_in_group("player")
if players.size() > 0:
player = players[0]

func _physics_process(_delta):
if player:
# 1. Calculate direction to the player
var direction = global_position.direction_to(player.global_position)
		
# 2. Set velocity towards the player
velocity = direction * speed
		
# 3. Flip sprite depending on which way it's moving
if direction.x > 0:
sprite.flip_h = false # Facing right
elif direction.x < 0:
sprite.flip_h = true  # Facing left
			
# 4. Move the enemy
move_and_slide()