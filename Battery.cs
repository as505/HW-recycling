using Godot;
using System;

public partial class Battery : Sprite3D
{
    public override void _Ready()
    {
        // Load solder scene
        var solder_scene = GD.Load<PackedScene>("res://solder_hitbox.tscn");
        var solder_instance_1 = solder_scene.Instantiate();
        var solder_instance_2 = solder_scene.Instantiate();
        var solder_instance_3 = solder_scene.Instantiate();

        AddChild(solder_instance_1);
        AddChild(solder_instance_2);
        AddChild(solder_instance_3);




        // Create position for solder joint
        Vector3 pos_solder = new Vector3((float)6.5, (float)-22.5, (float)4);
        // Copy for other joints
        Vector3 pos_solder_2 = pos_solder;
        Vector3 pos_solder_3 = pos_solder;
        // Adjust copies
        pos_solder_2.X += 3;
        pos_solder_3.X += 7;


        // Create shape for battery solder joints
        // Battery uses 2x3 solder joints, add padding for better game feel
        Vector3 shape_vector = new Vector3((float)2.5, (float)3.5, (float)10);
        BoxShape3D solder_box = new BoxShape3D();
        solder_box.Size = shape_vector;


        // Get collision shape node
        Area3D node_A3d = (Area3D)solder_instance_1.GetChild(0);
        CollisionShape3D node_col = (CollisionShape3D)node_A3d.GetChild(0);
        // Get collision shape node
        Area3D node_A3d_2 = (Area3D)solder_instance_2.GetChild(0);
        CollisionShape3D node_col_2 = (CollisionShape3D)node_A3d_2.GetChild(0);
        // Get collision shape node
        Area3D node_A3d_3 = (Area3D)solder_instance_3.GetChild(0);
        CollisionShape3D node_col_3 = (CollisionShape3D)node_A3d_3.GetChild(0);

        // Set position and shape
        node_col.Position = pos_solder;
        node_col.Shape = solder_box;

        node_col_2.Position = pos_solder_2;
        node_col_2.Shape = solder_box;
        
        node_col_3.Position = pos_solder_3;
        node_col_3.Shape = solder_box;
    }

}
