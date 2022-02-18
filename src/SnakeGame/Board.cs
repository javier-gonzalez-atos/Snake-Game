namespace SnakeGame;

public class Board
{
    public readonly int Height;
    public readonly int Width;
    public bool CaramelExists;

    public Board(int height, int width)
    {
        Height = height;
        Width = width;
        CaramelExists = false;
    }

    public void CreateBoard()
    {
        DrawLeftRightBorders();

        DrawTopBottomBorders();
    }

    private void DrawTopBottomBorders()
    {
        for (var i = 0; i <= Width; i++)
        {
            Utils.DrawPosition(i, 0, "#");
            Utils.DrawPosition(i, Height, "#");
        }
    }

    private void DrawLeftRightBorders()
    {
        for (var i = 0; i <= Height; i++)
        {
            Utils.DrawPosition(0, i, "#");
            Utils.DrawPosition(Width, i, "#");
        }
    }
}