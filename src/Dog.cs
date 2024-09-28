using Behaviours;
using Godot;
using System;
using System.Net.Http.Headers;


public partial class Dog : CharacterBody2D
{
	Shepherd shepherd;
	AutonomousAgent dogbrain = new AutonomousAgent(20,20, 70);
	Behaviours.Seek seek;

	bool hasBall = false;

	public override void _Ready()
	{
		shepherd = GetNode<Shepherd>("../Shepherd");
		seek = new Behaviours.Seek(shepherd,this);
		dogbrain.addBehaviour(seek);	
	}

	public void _on_dog_vision_area_entered(Node2D body)
	{

	}
	
	public void _on_dog_vision_body_entered(Node2D body)
	{
		if(body.IsInGroup("ball") && !hasBall)
		{
			GD.Print(body.Name);
			seek.changeTarget(body);
		}

		if(body.IsInGroup("shepherd"))
		{
			GD.Print(body.Name);
		}
	}


	public override void _PhysicsProcess(double delta)
	{

		var shepherdDir = shepherd.Position - this.Position; //seek target


		this.Velocity = dogbrain.Velocity*(float)delta;

		var collision = MoveAndCollide(this.Velocity);
		if (collision != null)
		{
			GD.Print("I collided with ", ((Node)collision.GetCollider()).IsInGroup("ball"));
			Velocity = Velocity.Slide(collision.GetNormal());

			if (((Node)collision.GetCollider()).IsInGroup("ball"))
			{
				hasBall = true;
				((Ball)collision.GetCollider()).taken();
				seek.changeTarget(shepherd);
			}

			if (((Node)collision.GetCollider()).IsInGroup("shepherd"))
			{
				if(hasBall)
				{
					((Shepherd)collision.GetCollider()).giveBall();
					seek.changeTarget(shepherd);
					hasBall = false;
				}
			}
		}

		return;
		//MoveAndSlide();

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








