using Godot;
using System;

public partial class SolderIronNode : Node3D
{
    public bool Equiped { get; set; }

    // Let GUI equip and un-equip item
    [Signal]
    public delegate void EquipToggleEventHandler();

    public override void _Ready()
    {
        // Spawn off-screen
        this.Position = new Vector3((float)0, (float)0, (float)1);
        // By default tool is not equiped
        this.Equiped = true;

        // Connect GUI signal to local function
        EquipToggle += ToggleEquipped;
    }

    // Toggles if item is equiped or not, used by GUI signal
    private void ToggleEquipped()
    {
        this.Equiped = !this.Equiped;
        return;
    }

    // Track mouse movement along all axis except Z
    // TODO fix mouse pos -> grid pos
    private void TrackMousePos()
    {
        // Get Mouse position
        Vector2 mousePosition = GetViewport().GetMousePosition();
        // Get current position of item
        Vector3 currentPos = this.Position;
        // Update X and Y to follow mouse, keep Z as is
        Vector3 newPos = new Vector3(mousePosition.X, mousePosition.Y, currentPos.Z);

        this.Position = newPos;

        return;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (this.Equiped == true)
        {
            TrackMousePos();
        }

        GD.Print(this.Position);
    }

}
