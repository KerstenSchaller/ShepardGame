using Godot;
using System;


public partial class LandscapeTilemap : TileMap
{

	Vector2I flatGrasGround = new Vector2I(0,1);
	Vector2I highGras1 = new Vector2I(1,1);
	Vector2I highGras2 = new Vector2I(2,1);
	Vector2I lowGras1 = new Vector2I(1,0);
	Vector2I lowGras2 = new Vector2I(2,0);
	Vector2I flowerGrasGround = new Vector2I(3,0);

	public override void _Ready()
	{
		setLayer0Random();
	}

	void setLayer0Random()
	{
		GD.Randomize();
		var random = new RandomNumberGenerator();
		for (int y = 0; y < 60; y++)
		{
			for (int x = 0; x < 90; x++)
			{
				random.Randomize();
				var randomPercentage = random.RandfRange(0,100);
				if (0  < randomPercentage && randomPercentage < 25)  { SetCell(0, new Vector2I(x, y), 0, highGras1);continue; }
				if (25 < randomPercentage && randomPercentage < 50)  { SetCell(0, new Vector2I(x, y), 0, highGras2);continue; }
				if (50 < randomPercentage && randomPercentage < 70)  { SetCell(0, new Vector2I(x, y), 0, lowGras1);continue; }
				if (70 < randomPercentage && randomPercentage < 90)  { SetCell(0, new Vector2I(x, y), 0, lowGras2);continue; }
				if (90 < randomPercentage && randomPercentage < 100) { SetCell(0, new Vector2I(x, y), 0, flowerGrasGround);continue; }

			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("mouseClickLeft"))
		{
			//setLayer0Random();
		}
	}


}
