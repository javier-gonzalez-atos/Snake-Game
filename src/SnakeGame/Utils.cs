namespace SnakeGame;

public static class Utils
{
    public static void DrawPosition(int x, int y, string character)
    {
        Console.SetCursorPosition(x,y);
        Console.WriteLine(character);
    }
}