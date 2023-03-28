namespace BallGame;

public partial class CameraController : Camera3D
{
	[Export] public NodePath NodePathPlayer { get; set; }

	private Player Player { get; set; }
	private Vector3 Offset { get; set; }

	private Vector2 MiddleClickedPos { get; set; }
	private bool HoldingMiddleClick { get; set; }

	public override void _Ready()
	{
		Player = GetNode<Player>(NodePathPlayer);
		Offset = Position - Player.Position;
	}

	public override void _PhysicsProcess(double delta)
	{
		Position = Player.Position + Offset;

		if (HoldingMiddleClick)
		{
			// yeah idk what im doing lol
			// something like a 3rd person camera controller
			// trying to do that
			var rotAmount = GetViewport().GetMousePosition() - MiddleClickedPos;
			rotAmount /= 1000;

			var rot = Rotation;
			rot.X += rotAmount.X;
			rot.Z += rotAmount.Y;
			Rotation = rot;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseBtn)
		{
			if (eventMouseBtn.ButtonIndex == MouseButton.Middle)
			{
				if (eventMouseBtn.Pressed)
					MiddleClickedPos = GetViewport().GetMousePosition();

				HoldingMiddleClick = eventMouseBtn.Pressed;
			}
		}
	}
}
