using Godot;
using System;
using System.Net.Http.Headers;


public partial class Dog : CharacterBody2D
{
	Shepherd shepherd;
	AutonomousAgent dogbrain = new AutonomousAgent(1500,1500, 70);

	public override void _Ready()
	{
		shepherd = GetNode<Shepherd>("../Shepherd");
	}

	public float getAcceleration()
	{
		Curve2D curve = new Curve2D();
		return 0;
		
	}

	public override void _PhysicsProcess(double delta)
	{

		var shepherdDir = shepherd.Position - this.Position; //seek target

		// move near shepherd
		if(shepherdDir.Length() > 30)
		{
			dogbrain.setTarget(shepherdDir);		
		}
		else
		{
			dogbrain.setTarget();
		}
		this.Velocity = dogbrain.Velocity*(float)delta;
		MoveAndSlide();
		

		/*
		if (Input.IsActionPressed("mouseClickLeft"))
		{
			var mousePos = GetGlobalMousePosition();
			this.Velocity = (mousePos - this.Position).Normalized() * (float)delta * 1200;
		}
		else
		{
			this.Velocity = new Vector2();

		}
		*/
	}
}
