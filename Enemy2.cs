using Godot;
using System;

public partial class Enemy2 : Enemy
{
    private const int Speed = 150;

    private Node2D target;

    public override void _PhysicsProcess(double delta)
    {

        if (target != null)
        {
            var direction = target.GlobalPosition - GlobalPosition;
            Velocity = direction.Normalized() * Speed;
        }

        else
        {
            Velocity = Vector2.Zero;
        }


        MoveAndSlide();
    }


    public void FoundPlayer(Node2D body)
    {
        GD.Print("Player found");
        if (body is Player)
            target = body;
    }


    public void LostPlayer(Node2D body)
    {
        GD.Print("Player lost");
        if (body is Player)
            target = null;
    }
}
        