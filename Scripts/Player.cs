global using Godot;
global using System;

namespace BallGame;

public partial class Player : RigidBody3D
{
	private SpringArm3D SpringArm { get; set; }

	public override void _Ready()
	{
		SpringArm = GetNode<SpringArm3D>("SpringArm3D");
		SpringArm.AddExcludedObject(GetRid());
	}

	public override void _PhysicsProcess(double delta)
	{
		SpringArm.Position = Position;

		var vel = AngularVelocity;
		vel.X -= Input.GetAxis("back", "forward");
		vel.Z -= Input.GetAxis("left", "right");

		AngularVelocity = vel;
	}
}
