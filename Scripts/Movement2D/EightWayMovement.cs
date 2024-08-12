using Godot;
using System;
using TestNothingSerious.Scripts.Helper;

public partial class EightWayMovement : CharacterBody2D
{
    [Export]
    public float Speed { get; private set; } = 5.0f;



    // GAme Loop Methods---------------------------------------------------------------------------
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();       
    }
    // Memeber Methods-----------------------------------------------------------------------------

    private void GetInput()
    {
        Vector2 inputDirection = Input.GetVector(
            InputMapActions.User.MOVE_LEFT,
            InputMapActions.User.MOVE_RIGHT,
            InputMapActions.User.MOVE_UP,
            InputMapActions.User.MOVE_DOWN
        );

        Velocity = inputDirection * Speed;
    }
}