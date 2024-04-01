using Godot;
using System;

public static partial class VectorHelper
{
		public static Vector2 PerpendicularClockwise(this Vector2 vector2)
	{
		return new Vector2(vector2.Y, -vector2.X);
	}

	public static Vector2 PerpendicularCounterClockwise(this Vector2 vector2)
	{
		return new Vector2(-vector2.Y, vector2.X);
	}
}

public static class AnimationHelper
{
	public enum Animations
	{
		IdleSouthWest,
		IdleNorthWest,
		IdleWest,
		IdleNorth,
		IdleSouth,
		IdleEast,
		IdleSouthEast,
		IdleNorthEast
	}

	public static void setAnimationToDirection(Vector2 direction, I8Directional animatedObect)
	{
		if(direction.Length() == 0)return;

		var angleRad = Mathf.Atan2(-direction.Y, -direction.X)+1.5*Mathf.Pi; // turn so that 0 degrees is a north
		angleRad = (angleRad >= 2*Mathf.Pi) ? angleRad - (2*Mathf.Pi) : angleRad; // reduce to under 2PI
		var angleDeg = angleRad * 360 / (2 * Math.PI);// convert to degree
		// angle increases clockwise
		
		float stepSize = 22.5f;


		if((angleDeg > 15*stepSize && angleDeg < 0)  || (angleDeg < stepSize && angleDeg > 0))
		{
			animatedObect.setNorth();return;
		}
		if(angleDeg > stepSize && angleDeg < 3*stepSize)
		{
			animatedObect.setNorthEast();return;
		}
		if(angleDeg > 3*stepSize && angleDeg < 5*stepSize)
		{
			animatedObect.setEast();return;
		}
		if(angleDeg > 5*stepSize && angleDeg < 7*stepSize)
		{
			animatedObect.setSouthEast();return;
		}
		if(angleDeg > 7*stepSize && angleDeg < 9*stepSize)
		{
			animatedObect.setSouth();return;
		}
		if(angleDeg > 9*stepSize && angleDeg < 11*stepSize)
		{
			animatedObect.setSouthWest();return;
		}
		if(angleDeg > 11*stepSize && angleDeg < 13*stepSize)
		{
			animatedObect.setWest();return;
		}
		if(angleDeg > 13*stepSize && angleDeg < 15*stepSize)
		{
			animatedObect.setNorthWest();return;
		}

	}
}
