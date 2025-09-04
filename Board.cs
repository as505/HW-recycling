using Godot;
using System;

public partial class Board : Sprite3D
{
	public static void Set_pos(Vector3 position)
	{
		GD.Print(position);
	}
	
	
	public override void _Ready()
	{
		this.Position = new Vector3((float)0, (float)0, (float)0);
		
		
		Vector3 cpuPos = new Vector3((float)-24, (float)-12, (float)0.1);
		Vector3 batPos = new Vector3((float)16, (float)3.5, (float)0.1);
		
		Sprite3D bat = (Sprite3D)this.GetChild(0);
		Sprite3D cpu = (Sprite3D)this.GetChild(1);
		
		cpu.Position = cpuPos;
		bat.Position = batPos;
		
		
	}
	
	
}
