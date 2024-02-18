using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DebugDrawHelper : Node2D
{
	private struct Line
	{
		public Vector2 start;
		public Vector2 end;
		public int width;
		public Color color;
	}

	List<Line> lines = new List<Line>();

	public void drawLine(Vector2 start, Vector2 end, int size, Color color)
	{
		Line line;
		line.start = start;
		line.end = end;
		line.width = size;
		line.color = color;
		lines.Add(line);
	}

	public override void _Ready()
	{
		this.ZIndex = 15;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		this.QueueRedraw();
	}

    public override void _Draw()
    {
        foreach(var l in lines)
		{
			DrawLine(l.start,l.end,l.color,l.width);
		}
		lines.Clear();
    }

}
