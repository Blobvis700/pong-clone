using Godot;
using System;

public partial class player : CharacterBody2D
{
	public int Speed  = 400;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y = Input.GetAxis("ui_up", "ui_down") * Speed;
		
		Velocity = velocity;
		MoveAndSlide();
	}

}
