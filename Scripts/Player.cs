global using Godot;
global using System;

namespace BallGame;

public partial class Player : RigidBody3D
{
	public override void _PhysicsProcess(double delta)
	{
		var vel = AngularVelocity;
		vel.X -= Input.GetAxis("back", "forward");
		vel.Z -= Input.GetAxis("left", "right");

		AngularVelocity = vel;
	}
}
