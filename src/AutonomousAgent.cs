using Godot;
using System;


class AutonomousAgent
{
    float mass;
    float maxSpeed;
    float maxForce;
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

    public AutonomousAgent(float _maxSpeed, float _maxForce, float _mass)
    {
        maxSpeed = _maxSpeed;
        maxForce = _maxForce;
        mass = _mass;
    }

    public void setTarget(Vector2 desired = new Vector2())
    {
        var steering = desired.Normalized()*maxSpeed - velocity;
        steering = (steering.LengthSquared() >= maxForce) ? steering.Normalized()*maxForce:steering;
        applyForce(steering);
    }

    public void applyForce(Vector2 force)
    {
        acceleration += force/mass;
        velocity += acceleration;
        GD.Print("s: " + velocity.Length() + " f: " + force.Length() + " mxF: " + maxForce);

    }
}