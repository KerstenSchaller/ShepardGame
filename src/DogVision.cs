using Godot;
using System;

public partial class DogVision : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var overlappingBodies = GetOverlappingBodies();
		foreach(var b in overlappingBodies)
		{
			//GD.Print("Something hit" + b.ToString());
		}
	}
}
