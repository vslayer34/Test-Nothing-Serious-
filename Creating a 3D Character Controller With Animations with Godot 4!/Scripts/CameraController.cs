using Godot;
using System;

public partial class CameraController : Node3D
{
	private MainCharacter _playerCharacter;
	private MainCharacterTestManagercs _gameManager;


    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        _gameManager = GetTree().Root.GetChild(0) as MainCharacterTestManagercs;
		_playerCharacter = _gameManager.PlayerCharacter;
    }

    public override void _Process(double delta)
    {
        GlobalPosition = _playerCharacter.GlobalPosition;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMovement)
		{
			Rotation += new Vector3(mouseMovement.Relative.Y / 1000.0f, mouseMovement.Relative.X / -1000.0f, 0);	
		}
    }
}
