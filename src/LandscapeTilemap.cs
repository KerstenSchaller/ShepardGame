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
	CharacterBody2D sheperd;
	Vector2I currentGateCell;



	private bool cellIsGate(Vector2I mapPos)
	{
		var atlasCoords = GetCellAtlasCoords(5,mapPos);
		if(atlasCoords.Y == 12 || atlasCoords.Y == 10) // tileset positions
		{
			return true;
		}
		return false;
	}

	private void openGateOnContact()
	{
		// process sheperd pos for gate animation
		const int closedGateRow  = 10;
		const int openGateRow  = 12;

		var shepherdMapPos = LocalToMap(ToLocal(sheperd.GlobalPosition));
		var isGate = cellIsGate(shepherdMapPos);
		if(isGate)
		{
			Vector2I closedGateTile = GetCellAtlasCoords(5,shepherdMapPos);
			currentGateCell = shepherdMapPos; // save cell to close the gate after sheperd leaves
			var c = new Vector2I(closedGateTile.X, closedGateTile.Y + 1);
			SetCell(5, currentGateCell, 0, new Vector2I(closedGateTile.X,openGateRow));
		}
		else
		{
			Vector2I closedGateTile = GetCellAtlasCoords(5, currentGateCell);
			Vector2I gate = GetCellAtlasCoords(0,shepherdMapPos);
			SetCell(5, currentGateCell, 0, new Vector2I(closedGateTile.X,closedGateRow));
		}
	}


	public override void _Ready()
	{
		setLayer0Random();
		sheperd = GetNode<CharacterBody2D>("../Shepherd");
	}

	void setLayer0Random()
	{
		int xRes = 70;
		int yRes = 150;
		GD.Randomize();
		var random = new RandomNumberGenerator();
		for (int y = 0; y < yRes; y++)
		{
			for (int x = 0; x < xRes; x++)
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
		
		openGateOnContact(); // check gates to open
		

		if(Input.IsActionJustPressed("mouseClickLeft"))
		{
			
			//setLayer0Random();
		}
	}


}
