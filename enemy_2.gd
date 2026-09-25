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

@onready var player_node: CharacterBody2D = get_parent().get_node("Player")
var speed: float = 35.0
var gravity = 15
	
@export_range(-1,1) var dir: int = 1

func _ready() -> void:
	if dir== 0:
		dir = 1
	$Sprite2D.flip_h = false if dir == 1 else true
	
func _physics_process(delta: float) -> void:
	if dir == 1 and (!$rightray.is_colliding() or $rightwallray.is_colliding()):
		$Sprite2D.flip_h = true
		dir = 0
		_wait_dir_change(-1)
	if dir == 1 and (!$leftray.is_colliding() or $leftwallray.is_colliding()):
		$Sprite2D.flip_h = false
		dir = 0
		_wait_dir_change(1)
		
	velocity.x = lerp(velocity.x, dir * speed, 10.0*delta)
	velocity.y += gravity
	move_and_slide()	

func _wait_dir_change(desired_dir: int):
	await get_tree().create_timer(0.5).timeout
	dir = desired_dir


func _on_area_2d_body_entered(body: Node2D) -> void:
	if body == player_node:
		get_tree().reload_current_scene("reload_current_scene")
		
