using Godot;
using System;

public partial class SolderJointArea3d : Area3D
{
    public void _on_area_entered(Area3D area)
    {
        //GD.Print("JOINT COL");
        destroySelf();

    }

    // Remove self from sceene
    private void destroySelf()
    {
        // Go to head Node3D node to remove entire instanced sceene 
        this.GetParent().QueueFree();
    }
}
