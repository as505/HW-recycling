using Godot;
using System;

public partial class SolderJointArea3d : Area3D
{
    public void _on_area_entered(Area3D area)
    {
        GD.Print("JOINT COL");
    }
}
