using Behaviours;
using Godot;
using System;
using System.Collections.Generic;



namespace Behaviours
{
    interface Behaviour
    {
        Vector2 getDesiredDirection();
    }

    class Seek : Behaviour
    {
        Node2D target;
        Node2D parent;
        public Seek(Node2D _target, Node2D _parent)
        {
            this.target = _target;
            this.parent = _parent;
        }
        public Vector2 getDesiredDirection()
        {
            return target.Position - parent.Position;
        }
    }
}

class AutonomousAgent
{
    float mass;
    float maxSpeed;
    float maxForce;
    Vector2 acceleration;
    Vector2 velocity;

    List<Behaviours.Behaviour> behaviours = new List<Behaviours.Behaviour>();
    public Vector2 Velocity
    {
        get
        {
            acceleration = new Vector2();
            foreach(var behaviour in behaviours)
            {
                applyForce(behaviour.getDesiredDirection());
            }
            return velocity;
        }
    }

    public AutonomousAgent(float _maxSpeed, float _maxForce, float _mass)
    {
        maxSpeed = _maxSpeed;
        maxForce = _maxForce;
        mass = _mass;
    }

    public void addBehaviour(Behaviours.Behaviour _behaviour)
    {
        behaviours.Add(_behaviour);
    }

    public void removeBehaviour(Behaviours.Behaviour _behaviour)
    {
        behaviours.Remove(_behaviour);
    }

    public void applyForce(Vector2 desired)
    {
        var steering = desired.Normalized()*maxSpeed - velocity;
        steering = (steering.LengthSquared() >= maxForce) ? steering.Normalized()*maxForce:steering;

        acceleration += steering/mass;
        velocity += acceleration;
        GD.Print("s: " + velocity.Length() + " f: " + steering.Length() + " mxF: " + maxForce);

    }
}