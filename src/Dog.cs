using Godot;
using System;


public partial class Dog : CharacterBody2D
{
	Shepherd shepherd;

	public override void _Ready()
	{
		shepherd = GetNode<Shepherd>("../Shepherd");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		// vector to shepherd
		var shepherdDir = (this.Position - shepherd.Position).Normalized();
		//shepherdDir = new Vector2(Mathf.Abs(shepherdDir.X),Mathf.Abs(shepherdDir.Y));
		// orthogonal vectors -> x1*x2 + y1*y2 = 0
		// y2 = -(x1*x2)/y1
		// x2=1
		// y2 = -x1/y1
		Vector2	orthVec =  new Vector2(1, -shepherdDir.X / shepherdDir.Y).Normalized();
		if (shepherdDir.Y > 0)
		{	
			// change direction of vector if dog is on other side of shepherd
			orthVec *= -1;
		}
		this.Velocity = orthVec * (float)delta * 1200;

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
		MoveAndSlide();
	}
}
