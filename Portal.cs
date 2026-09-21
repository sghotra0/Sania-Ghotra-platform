using Godot;
using System;

public partial class Portal : Area2D
{
    [Export]
    public string FileName;
    
    public void OnBodyEntered(Node2D node)
    {
        if (node is Player)
            GetTree().ChangeSceneToFile(FileName);
    }
    
}
