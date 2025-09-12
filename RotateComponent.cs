using Godot;
using System;


namespace RotateHandler
{
    class RotateComponentClass
    {

        public static void RotateComponent(Sprite3D sprite)
        {
            Vector3 zaxis = new Vector3(0, 0, 1);
            sprite.Rotate(zaxis, (float)0.01);
            return;
        }
    }
}
