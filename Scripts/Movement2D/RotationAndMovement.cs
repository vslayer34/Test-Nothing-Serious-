using Godot;
using System;
using TestNothingSerious.Scripts.Helper;

public partial class RotationAndMovement : CharacterBody2D
{
	[Export]
	public float Speed { get; private set; } = 400.0f;

	[Export]
	public float RotationSpeed { get; private set; } = 1.5f;


	private float _rotationDirection;
	private float _forwardDirection;



    // Game Loop Methods---------------------------------------------------------------------------
    
	public override void _PhysicsProcess(double delta)
    {
		GetInput();
        Rotation += _rotationDirection * RotationSpeed * (float) delta;
		MoveAndSlide();
    }

    // Memeber Methods-----------------------------------------------------------------------------
	
	private void GetInput()
	{
		_rotationDirection = Input.GetAxis(InputMapActions.User.MOVE_LEFT, InputMapActions.User.MOVE_RIGHT);
		_forwardDirection = Input.GetAxis(InputMapActions.User.MOVE_UP, InputMapActions.User.MOVE_DOWN);

		Velocity = _forwardDirection * Transform.Y * Speed;
	}
}
