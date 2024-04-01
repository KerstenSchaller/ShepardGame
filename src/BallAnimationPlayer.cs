using Godot;
using System;

public partial class BallAnimationPlayer : Sprite2D
{
	public AnimationPlayer animationPlayer;
	
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}


}
