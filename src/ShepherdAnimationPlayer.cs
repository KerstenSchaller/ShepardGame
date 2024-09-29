using Godot;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

public partial class ShepherdAnimationPlayer : AnimationPlayer, I8Directional
{

	AnimationHelper animationHelper = new AnimationHelper();

	Dictionary<AnimationHelper.Animations, string> animationMap = new Dictionary<AnimationHelper.Animations, string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		animationMap.Add(AnimationHelper.Animations.IdleNorthWest,"IdleNorthWest");
		animationMap.Add(AnimationHelper.Animations.IdleSouthWest,"IdleSouthWest");
		animationMap.Add(AnimationHelper.Animations.IdleWest,"IdleWest");
		animationMap.Add(AnimationHelper.Animations.IdleEast,"IdleEast");
		animationMap.Add(AnimationHelper.Animations.IdleNorth,"IdleNorth");
		animationMap.Add(AnimationHelper.Animations.IdleSouth,"IdleSouth");
		animationMap.Add(AnimationHelper.Animations.IdleNorthEast,"IdleNorthEast");
		animationMap.Add(AnimationHelper.Animations.IdleSouthEast,"IdleSouthEast");
	}

	public override void _PhysicsProcess(double delta)
	{
		Shepherd shepherd = GetParent<Node2D>().GetParent<Shepherd>();
		var velocity = shepherd.Velocity.Normalized();
		//animationHelper.setAnimationToDirection(velocity, this);
		animationHelper.setAnimationToDirection( shepherd.heading, this);

	}




	private void setAnimation(AnimationHelper.Animations animation, bool flipHorizontal = false)
	{
		this.CurrentAnimation = animationMap[animation];
		var parent = this.GetParent<Sprite2D>();
		if(parent != null)parent.FlipH = flipHorizontal;
	}

	public void setNorth()
	{
		setAnimation(AnimationHelper.Animations.IdleNorth);
	}

	public void setNorthEast()
	{
		setAnimation(AnimationHelper.Animations.IdleNorthEast);
	}

	public void setNorthWest()
	{
		setAnimation(AnimationHelper.Animations.IdleNorthWest);
	}

	public void setSouthEast()
	{
		setAnimation(AnimationHelper.Animations.IdleSouthEast);
	}

	public void setSouthWest()
	{
		setAnimation(AnimationHelper.Animations.IdleSouthWest);
	}

	public void setSouth()
	{
		setAnimation(AnimationHelper.Animations.IdleSouth);
	}

	public void setWest()
	{
		setAnimation(AnimationHelper.Animations.IdleWest);
	}

	public void setEast()
	{
		setAnimation(AnimationHelper.Animations.IdleEast);
	}

}
