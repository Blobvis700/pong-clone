using Godot;
using System;

public partial class Global : Node
{
 	public static Global Instance { get; private set; }

	public int ScorePlayer1 { get; set; }
	public int ScorePlayer2 { get; set; }
	public int Direction { get; set; }

	public override void _Ready()
	{
		Instance = this;
		Direction = -1;

	}
	
}
