using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	Vector2 targetPos;

	AnimationPlayer animator;

	public override void _Ready()
	{
		//animator = GetNode<AnimationPlayer>("BallAnimation/AnimationPlayer");

	}

	public void throwTo(Vector2 _targetPos)
	{
		targetPos = _targetPos;
	}

	public void taken()
	{
		QueueFree();
	}

	public override void _PhysicsProcess(double delta)
	{
		if(targetPos != new Vector2())
		{
			var direction = targetPos - this.GlobalPosition; 
			
			if(direction.Length() >= 2)
			{
				this.Position = this.Position + direction.Normalized()*100*(float)delta;
				//animator.CurrentAnimation = "rolling";
				//animator.Play();
			}
			else
			{
				//animator.Stop();
				targetPos = new Vector2();
			}

		}


	}


}
