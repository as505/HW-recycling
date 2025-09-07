using Godot;
using System;

public partial class SolderCollision : Area3D
{
    public void _on_area_entered(Area3D area)
    {
        GD.Print("LASER COL");
    }
}
