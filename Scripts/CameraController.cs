namespace BallGame;

public partial class CameraController : SpringArm3D
{
	[Export] public NodePath NodePathPlayer { get; set; }

	//private Player Player { get; set; }
	//private Vector3 Offset { get; set; }

	private Vector2 MiddleClickedPos { get; set; }
	private bool HoldingMiddleClick { get; set; }

	private Vector3 PrevRot { get; set; }

	public override void _Ready()
	{
		//Player = GetNode<Player>(NodePathPlayer);
		//Offset = Position - Player.Position;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (HoldingMiddleClick)
		{
			var amount = GetViewport().GetMousePosition() - MiddleClickedPos;

			var rot = Rotation;
			rot.Y = -amount.X * 0.01f; // horizontal
			rot.X = Mathf.Clamp(-amount.Y * 0.01f, -Mathf.Pi / 2, 0.1f); // vertical
			
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
