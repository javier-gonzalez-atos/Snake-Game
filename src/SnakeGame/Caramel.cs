
namespace SnakeGame;

public class Caramel
{
    public Position Position { get; set; }

    public Caramel(int x, int y)
    {
        Position = new Position(x, y);
    }

    public void DrawCaramel()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Utils.DrawPosition(Position.X, Position.Y, "O");
        Console.ResetColor();
    }

    public static Caramel CreateCaramel(Snake snake, Board board)
    {
        // var invalidCaramel = true;
        int caramelPositionX;
        int caramelPositionY;
        
        do
        {
            var random = new Random();
            caramelPositionX = random.Next(1, board.Width - 1);
            caramelPositionY = random.Next(1, board.Height - 1);
            // invalidCaramel = snake.PositionExistsInTail(caramelPositionX, caramelPositionY);
        } while(snake.PositionExistsInTail(caramelPositionX, caramelPositionY));

        board.CaramelExists = true;
        
        return new Caramel(caramelPositionX, caramelPositionY);

    }

}