using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	public int Speed  = 400;
	public int Direction;

	public float YDirection = 0;
	private CharacterBody2D Player;
	private Label Score1;
	private Label Score2;
	
	public int ScorePlayer1 = 0;
	public int ScorePlayer2 = 0;
	public override void _Ready()
	{
		Player = GetNode<CharacterBody2D>("../Player");
		Score1 = GetNode<Label>("../Control/HBoxContainer/VBoxContainer/HBoxContainer/Score1");
		Score2 = GetNode<Label>("../Control/HBoxContainer/VBoxContainer/HBoxContainer/Score2");
		Score1.Text = Global.Instance.ScorePlayer1.ToString();
		Score2.Text = Global.Instance.ScorePlayer2.ToString();
		Direction = Global.Instance.Direction;
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.X = Direction * Speed;
		velocity.Y = YDirection * 200;
		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			if (((collision.GetCollider() as Node).Name == "Player" || (collision.GetCollider() as Node).Name == "Player2") && i == 0)
			{
				Vector2 Position = collision.GetPosition();
				Vector2 PlayerPosition = Player.Position;
				float Difference = Position.Y - PlayerPosition.Y;
				Direction = Direction * -1;
				YDirection = Difference / 100;
			}
			if ((collision.GetCollider() as Node).Name == "Walls" && i == 0)
			{
				YDirection = YDirection * -1;
			}
		}
	}
	
	public void _on_goal_1_body_entered(Node2D body) {
		if (body.Name== "Ball") {
			Global.Instance.ScorePlayer2++;
			Score2.Text = Global.Instance.ScorePlayer2.ToString();
			Global.Instance.Direction = -1;
			GetTree().ReloadCurrentScene();
		}
	}
	
	public void _on_goal_2_body_entered(Node2D body) {
		if (body.Name== "Ball") {
			Global.Instance.ScorePlayer1++;
			Score1.Text = Global.Instance.ScorePlayer1.ToString();
			Global.Instance.Direction = 1;
			GetTree().ReloadCurrentScene();
		}
	}
}
