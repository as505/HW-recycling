using Godot;
using System;

// Defines magic numbers 
static class MAGIC
{
    public const float HEIGTH = 5;
}
public partial class SolderIronNode : Node3D
{

    public bool Equiped { get; set; }
    // Let GUI equip and un-equip item
    [Signal]
    public delegate void EquipToggleEventHandler();

    public override void _Ready()
    {
        // Spawn off-screen
        this.Position = new Vector3((float)0, (float)0, (float)MAGIC.HEIGTH);
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


    private void TrackMousePos()
    {
        var y = this.Position.Y;
        // Get Mouse position on screen
        Vector2 mousePosition = GetViewport().GetMousePosition();
        // Fetch camera for viewport
        Camera3D camera = this.GetViewport().GetCamera3D();
        // Translates cusor on screen to in-game 3d coordinate location
        // Uses Y axis of laser
        Vector3 projectedCursorCoord = camera.ProjectPosition(mousePosition, MAGIC.HEIGTH);

        // Switch Z and Y axis from projection
        Vector3 newPos = new Vector3(projectedCursorCoord.X, -projectedCursorCoord.Z, projectedCursorCoord.Y);

        // Apply new position
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
    }

}
