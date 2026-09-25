extends CharacterBody2D


const SPEED = 300.0
const JUMP_VELOCITY = -400.0


func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("ui_left", "ui_right")
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()
	
	
extends CharacterBody2D

@onready var player_node: CharacterBody2D = get_parent().get_node("Player")
var speed: float = 65.0
	
var should_chase: bool = false
	
func _physics_process(delta: float) -> void:
		if should_chase:
			var direction = (player_node.global_position-global_position).normalized()
			velocity = lerp(velocity, direction * speed, 8.5*delta)
			move_and_slide()
			if direction.x > 0:
				$Sprite2D.flip_h = false
			elif direction.x < 0:
				$Sprite2D.flip_h = true

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body == player_node:
		get_tree().call_deferred("reload_current_scene")
func _on_enter_area_body_entered(body: Node2D) -> void:
	if body == player_node:
		should_chase = true

func _on_exit_area_body_exited(body: Node2D) -> void:
	if body == player_node:
		should_chase = false