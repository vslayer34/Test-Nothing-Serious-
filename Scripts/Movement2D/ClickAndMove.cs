using Godot;
using System;
using TestNothingSerious.Scripts.Helper;

public partial class ClickAndMove : CharacterBody2D
{
	[Export]
	public float Speed { get; private set; } = 400.0f;

	private Vector2 _targetPosition;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(InputMapActions.User.CLICK))
		{
			_targetPosition = GetGlobalMousePosition();
		}
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Position.DirectionTo(_targetPosition) * Speed;

		LookAt(_targetPosition);

		if (Position.DistanceTo(_targetPosition) > 10)
		{
			MoveAndSlide();
		}
    }
    // Memeber Methods-----------------------------------------------------------------------------
}
