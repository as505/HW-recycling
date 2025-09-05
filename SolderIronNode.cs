using Godot;
using System;



public partial class SolderIronNode : Node3D
{
    // This is the gameplay border not including GUI, TODO define outside of this file 
    public const int GAMEHEIGHT = 100;
    public const int GAMEWIDTH = 100;
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

    private Vector2 ConvertScreenResolutionToGamespaceResolution(Vector2 mousePos)
    {
        // Get the game window resolution, this is what the cursor uses
        Vector2 currentGameResolution = DisplayServer.ScreenGetSize();

        float ratio = currentGameResolution.Y / GAMEWIDTH;

        // Convert
        float convertedX = mousePos.X / ratio;
        float convertedY = mousePos.Y / ratio;

        // Constrain to gamespace
        float X = Math.Min(Math.Max(convertedX, 0), GAMEWIDTH);
        float Y = Math.Min(Math.Max(convertedY, 0), GAMEHEIGHT);

        Vector2 convertedVector = new Vector2(X, Y);
        return convertedVector;
    }
    
    // Track mouse movement along all axis except Z
    // TODO fix mouse pos -> grid pos
    private void TrackMousePos()
    {
        // Get Mouse position
        Vector2 mousePosition = GetViewport().GetMousePosition();
        // Translate to in game grid
        mousePosition = ConvertScreenResolutionToGamespaceResolution(mousePosition);


        // Get current position of item
        Vector3 currentPos = this.Position;
        // Update X and Y to follow mouse, keep Z as is
        Vector3 newPos = new Vector3(mousePosition.X / 10, -mousePosition.Y / 10, currentPos.Z);

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
