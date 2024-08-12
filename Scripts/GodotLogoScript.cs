using Godot;
using System;

[Tool]
public partial class GodotLogoScript : Node2D
{
	private float[,] _headCorodinates = new float[,]
	{
		{ 22.952f, 83.271f },  { 28.385f, 98.623f },
        { 53.168f, 107.647f }, { 72.998f, 107.647f },
        { 99.546f, 98.623f },  { 105.048f, 83.271f },
        { 105.029f, 55.237f }, { 110.740f, 47.082f },
        { 102.364f, 36.104f }, { 94.050f, 40.940f },
        { 85.189f, 34.445f },  { 85.963f, 24.194f },
        { 73.507f, 19.930f },  { 68.883f, 28.936f },
        { 59.118f, 28.936f },  { 54.494f, 19.930f },
        { 42.039f, 24.194f },  { 42.814f, 34.445f },
        { 33.951f, 40.940f },  { 25.637f, 36.104f },
        { 17.262f, 47.082f },  { 22.973f, 55.237f }
	};

    private float[,] _mouthCorodinates = new float[,]
    {
        { 22.817f, 81.100f }, { 38.522f, 82.740f },
        { 39.001f, 90.887f }, { 54.465f, 92.204f },
        { 55.641f, 84.260f }, { 72.418f, 84.177f },
        { 73.629f, 92.158f }, { 88.895f, 90.923f },
        { 89.556f, 82.673f }, { 105.005f, 81.100f }
    };


	private Vector2[] _head;

    private Vector2[] _mouth;
    private float _mouthWidth = 4.4f;


    [Export]
    private float _rotationSpeed = 1.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        Rotation = 0.0f;
        _head = ConvertFloatArrayToVector2Array(_headCorodinates);
        _mouth = ConvertFloatArrayToVector2Array(_mouthCorodinates);
    }


    public override void _Process(double delta)
    {
        Rotation -= _rotationSpeed * (float)delta;
    }


    public override void _Draw()
    {
        Color godotBlue = new Color("478cbf");
        DrawPolygon(_head, new Color[]{ godotBlue });
        // DrawPolygon(_head, new Color[]{ Colors.Blue });
        DrawPolyline(_mouth, Colors.White, _mouthWidth);

        // Four circles for the 2 eyes: 2 white, 2 grey.
        DrawCircle(new Vector2(42.479f, 65.4825f), 9.3905f, Colors.White);
        DrawCircle(new Vector2(85.524f, 65.4825f), 9.3905f, Colors.White);
        DrawCircle(new Vector2(43.423f, 65.92f), 6.246f, Colors.Black);
        DrawCircle(new Vector2(84.626f, 66.008f), 6.246f, Colors.Black);

        // Draw a short but thick white vertical line for the nose.
        DrawLine(new Vector2(64.273f, 60.564f), new Vector2(64.273f, 74.349f), Colors.White, 5.8f);

        // Draw GODOT text below the logo with the default font, size 22.
        DrawString(
            ThemeDB.FallbackFont, 
            new Vector2(20.0f, 130.0f), 
            "GODOT", HorizontalAlignment.Center, 
            90.0f, 22
        );
    }

    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Convert the array of floats into an array of Vector2.
    /// </summary>
    /// <param name="targetArray"></param>
    /// <returns></returns>
    private Vector2[] ConvertFloatArrayToVector2Array(float[,] targetArray)
	{
		int size = targetArray.GetUpperBound(0);
		Vector2[] vectorArray = new Vector2[size + 1];

		for (int i = 0; i <= size; i++)
		{
			vectorArray[i] = new Vector2(targetArray[i, 0], targetArray[i, 1]);
		}

		return vectorArray;
	}
}
