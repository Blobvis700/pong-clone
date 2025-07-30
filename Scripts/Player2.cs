using Godot;
using System;

public partial class Player2 : CharacterBody2D
{
	public int Speed  = 400;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y = Input.GetAxis("upp2", "downp2") * Speed;
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
