using Godot;
using System;
using TestNothingSerious.Scripts.Helper;

public partial class MovementAndMouseRotation : CharacterBody2D
{
	[Export]
	public float Speed { get; private set; } = 400.0f;

	private float _forwardDirection;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
		MoveAndSlide();
    }
    // Member Methods------------------------------------------------------------------------------
	private void GetInput()
	{
		LookAt(GetGlobalMousePosition());
		_forwardDirection = Input.GetAxis(InputMapActions.User.MOVE_DOWN, InputMapActions.User.MOVE_UP);
		Velocity = _forwardDirection * Transform.X * Speed;
	}
}
