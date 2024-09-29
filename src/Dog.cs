using Behaviours;
using Godot;
using System;
using System.Net.Http.Headers;


public partial class Dog : CharacterBody2D
{
	Shepherd shepherd;
	AutonomousAgent dogbrain = new AutonomousAgent(20,25, 2);
	Behaviours.Seek seek;
	Behaviours.CircleAround circleAround;

	enum BehaviourState{FollowShepherd, returnBall}
	BehaviourState behaviourState = BehaviourState.FollowShepherd;

	bool hasBall = false;

	public override void _Ready()
	{
		shepherd = GetNode<Shepherd>("../Shepherd");
		seek = new Behaviours.Seek(shepherd,this);
		circleAround = new Behaviours.CircleAround(shepherd,this);
		dogbrain.addBehaviour(circleAround);
		dogbrain.addBehaviour(seek);
		circleAround.disable();
	}

	public void _on_dog_vision_area_entered(Node2D body)
	{

	}
	
	public void _on_dog_vision_body_entered(Node2D body)
	{
		if(body.IsInGroup("ball") && !hasBall)
		{
			seek.changeTarget(body);
			seek.enable();
			circleAround.disable();
			behaviourState = BehaviourState.returnBall;
			GD.Print("Dog sees " + body.Name);
		}

		if(body.IsInGroup("shepherd"))
		{
			//GD.Print(body.Name);
		}
	}

int count= 0;
	public override void _PhysicsProcess(double delta)
	{

		this.Velocity = dogbrain.Velocity*(float)delta;

		var collision = MoveAndCollide(this.Velocity);

		if(collision != null)
		{
			GD.Print("collision happening");
			Velocity = Velocity.Slide(collision.GetNormal());
		}
	GD.Print("v: " + Velocity);
		//GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
		switch (behaviourState)
		{
			case BehaviourState.FollowShepherd:
				//GD.Print((shepherd.Position - this.Position).Length());
				if ((shepherd.Position - this.Position).Length() <= 15)
				{
					seek.disable();
					circleAround.enable();
				}
				if ((shepherd.Position - this.Position).Length() > 20)
				{
					//GD.Print("turn off circlearound " + count++);
					seek.enable();
					circleAround.disable();
				}
				break;

			case BehaviourState.returnBall: // seek the ball and return it to the shepherd
				if (collision != null)
				{
					if (((Node)collision.GetCollider()).IsInGroup("ball"))
					{
						hasBall = true;
						((Ball)collision.GetCollider()).taken();
						seek.changeTarget(shepherd);
					}
					if (((Node)collision.GetCollider()).IsInGroup("shepherd"))
					{
						if (hasBall)
						{
							((Shepherd)collision.GetCollider()).receiveBall();
							seek.changeTarget(shepherd);
							hasBall = false;
							behaviourState = BehaviourState.FollowShepherd;
						}
					}
				}
				break;
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








