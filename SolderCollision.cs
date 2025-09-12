using Godot;
using System;

public partial class SolderCollision : Area3D
{
    public override void _Ready()
    {
        // Get Component we are connected to
        Sprite3D parent = (Sprite3D)this.GetParent();
        //GD.Print(parent.RemoveSolderJoint());
        //Connect("RemoveSolderJoint", (Godot.Callable) parent);

        base._Ready();
    }

    public void _on_area_entered(Area3D area)
    {
        //GD.Print("LASER COL");

    }
}
