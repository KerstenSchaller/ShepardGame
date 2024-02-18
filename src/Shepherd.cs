using Godot;
using System;

public partial class Shepherd : CharacterBody2D
{
	CharacterBody2D dog;
	public Vector2 heading = new Vector2();

	public override void _Ready()
	{
		dog = GetNode<CharacterBody2D>("../Dog");

	}

	public override void _PhysicsProcess(double delta)
	{
		// update heading
		var dogPos = dog.Position;
		heading = dogPos - this.Position;

	
	}
}
