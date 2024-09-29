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

public class AnimationHelper
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


	double lastAngle = 0;
	public void setAnimationToDirection(Vector2 direction, I8Directional animatedObect)
	{

		var angleRad = Mathf.Atan2(-direction.Y, -direction.X)+1.5*Mathf.Pi; // turn so that 0 degrees is a north
		angleRad = (angleRad >= 2*Mathf.Pi) ? angleRad - (2*Mathf.Pi) : angleRad; // reduce to under 2PI
		var angleDeg = angleRad * 360 / (2 * Math.PI);// convert to degree
		// angle increases clockwise
		
		if(direction.Length() == 0)
		{
			//GD.Print("length of direction is 0");
			angleDeg = lastAngle;
		}
		else
		{
			lastAngle = angleDeg;
		}


		float stepSize = 22.5f;

		//GD.Print("angleDeg " + angleDeg);
		bool debug = false;
		if((angleDeg > 15*stepSize && angleDeg < 16*stepSize)  || (angleDeg < stepSize && angleDeg >= 0))
		{
			if(debug)GD.Print("setNorth " + angleDeg);
			animatedObect.setNorth();return;
		}
		if(angleDeg > stepSize && angleDeg <= 3*stepSize)
		{
			if(debug)GD.Print("setNorthEast " + angleDeg);
			animatedObect.setNorthEast();return;
		}
		if(angleDeg > 3*stepSize && angleDeg <= 5*stepSize)
		{
			if(debug)GD.Print("setEast " + angleDeg);
			animatedObect.setEast();return;
		}
		if(angleDeg > 5*stepSize && angleDeg <= 7*stepSize)
		{
			if(debug)GD.Print("setSouthEast " + angleDeg);
			animatedObect.setSouthEast();return;
		}
		if(angleDeg > 7*stepSize && angleDeg <= 9*stepSize)
		{
			if(debug)GD.Print("setSouth " + angleDeg);
			animatedObect.setSouth();return;
		}
		if(angleDeg > 9*stepSize && angleDeg <= 11*stepSize)
		{
			if(debug)GD.Print("setSouthWest " + angleDeg);
			animatedObect.setSouthWest();return;
		}
		if(angleDeg > 11*stepSize && angleDeg <= 13*stepSize)
		{
			if(debug)GD.Print("setWest " + angleDeg);
			animatedObect.setWest();return;
		}
		if(angleDeg > 13*stepSize && angleDeg <= 15*stepSize)
		{
			if(debug)GD.Print("setNorthWest " + angleDeg);
			
			animatedObect.setNorthWest();return;
		}
		GD.Print("set to nothing " + angleDeg);

	}
}
