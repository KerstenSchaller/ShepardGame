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
		if (Input.IsActionPressed("mouseClickLeft"))
		{
			var mousePos = GetGlobalMousePosition();
			
			throwBall(mousePos); 
			GD.Print("mpos: " + mousePos);
		}

		// Movement
		float fdelta = (float)delta;
		this.Velocity = new();
		if (Input.IsKeyPressed(Key.W)) //Up
		{
			this.Velocity = new Vector2( this.Velocity.X, -800*fdelta);
		}
		if (Input.IsKeyPressed(Key.S)) //down
		{
			this.Velocity = new Vector2( this.Velocity.X, 800*fdelta);
		}
		if (Input.IsKeyPressed(Key.A)) //left
		{
			this.Velocity = new Vector2( -800*fdelta, this.Velocity.Y);
		}
		if (Input.IsKeyPressed(Key.D)) //right
		{
			this.Velocity = new Vector2( 800*fdelta, this.Velocity.Y);
		}
		heading = this.Velocity;
		MoveAndSlide();
	
	}

	public void throwBall(Vector2 targetPos)
	{
		// spawn ball
		Ball ball = GD.Load<PackedScene>("res://scenes/Ball.tscn").Instantiate<Ball>();
		GetParent().CallDeferred("add_child",ball);
		ball.ZIndex = 2;
		ball.Position = new Vector2(this.Position.X,this.Position.Y-4);
		ball.throwTo(targetPos);
	}
}
