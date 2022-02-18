using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SnakeGame;

public class Snake
{
    public List<Position> Tail { get; set; }
    public Direction Direction { get; set; }
    public int Score { get; set; }
    public bool IsAlive { get; set; }
    
    public Snake(int x, int y)
    {
        Tail = new List<Position>
        {
            new Position(x,y)
        };
        Direction = Direction.Right;
        IsAlive = true;
    }

    public void DrawSnake()
    {
        foreach (var position in Tail)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Utils.DrawPosition(position.X, position.Y, "x");
        }
        Console.ResetColor();
    }

    public void CheckHealthStatus(Board board)
    {
        var firstPosition = Tail.First();
        IsAlive = !IsHeadOnBorder(board, firstPosition) && !SnakeSelfEaten(firstPosition);
    }

    public bool SnakeSelfEaten(Position firstPosition)
    {
        return Tail.Skip(1).Any(t => t.X == firstPosition.X && t.Y == firstPosition.Y);
    }
    
    private bool IsHeadOnBorder(Board board, Position firstPosition)
    {
        return firstPosition.Y == 0 || firstPosition.Y == board.Height || firstPosition.X == 0 ||
               firstPosition.X == board.Width;
    }
    
    public void Move(bool caramelEaten)
    {
        var newTail = new List<Position> { UpdateTail() };
        newTail.AddRange(Tail);

        if (!caramelEaten)
        {
            newTail.Remove(newTail.Last());
        }

        Tail = newTail;
    }

    private Position UpdateTail()
    {
        var newXPosition = Tail.First().X;
        var newYPosition = Tail.First().Y;

        switch (Direction)
        {
            case Direction.Up:
                newYPosition--;
                break;
            case Direction.Down:
                newYPosition++;
                break;
            case Direction.Left:
                newXPosition--;
                break;
            case Direction.Right:
                newXPosition++;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return new Position(newXPosition, newYPosition);
    }

    public bool PositionExistsInTail(int x, int y)
    {
        return Tail.Any(t => t.X == x && t.Y == y);
    }

    public bool EatCaramel(Caramel caramel, Board board)
    {
        Console.WriteLine();
        
        if (!PositionExistsInTail(caramel.Position.X, caramel.Position.Y)) return false;
        
        Score += 10;
        board.CaramelExists = false;
        return true;

    }

    // /// <summary>
    // /// Test with no parameters
    // /// </summary>
    // public void Test()
    // {
    //     
    // }
    //
    // /// <summary>
    // /// Test with X
    // /// </summary>
    // /// <param name="x"></param>
    // public void Test(int x)
    // {
    //     
    // }
    //
    // /// <summary>
    // /// Test with string
    // /// </summary>
    // /// <param name="test"></param>
    // public void Test(string test)
    // {
    //     
    // }
    
}