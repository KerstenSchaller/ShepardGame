using Godot;
using System;


class AutonomousAgent
{
    float mass;
    float maxSpeed;
    Vector2 acceleration;
    Vector2 velocity;


    public Vector2 Velocity
    {
        get
        {
            acceleration = new Vector2();
            return velocity;
        }
    }

    public AutonomousAgent(float _maxSpeed, float _mass)
    {
        maxSpeed = _maxSpeed;
        mass = _mass;
    }

    public void setDesiredVelocity(Vector2 desired)
    {
        var steering = desired.Normalized()*maxSpeed - velocity;
        applyForce(steering);
    }

    public void applyForce(Vector2 force)
    {
        acceleration += force/mass;
        velocity += acceleration;
    }
}