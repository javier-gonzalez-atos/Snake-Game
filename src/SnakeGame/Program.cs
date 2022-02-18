// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using SnakeGame;

Board board = new Board(10,30);

Snake snake = new Snake(5, 5);
Caramel caramel = new Caramel(0, 0);
var caramelEaten = false;

do
{
    Console.Clear();
    board.CreateBoard();
    snake.Move(caramelEaten);

    caramelEaten = snake.EatCaramel(caramel, board);
    snake.DrawSnake();

    if (!board.CaramelExists)
    {
        caramel = Caramel.CreateCaramel(snake, board);
    }
    caramel.DrawCaramel();

    var sw = Stopwatch.StartNew();
    while (sw.ElapsedMilliseconds <= 250)
    {
        snake.Direction = ReadMovement(snake.Direction);
    }
    
    snake.CheckHealthStatus(board);

} while (snake.IsAlive);

Console.ForegroundColor = ConsoleColor.Red;
Utils.DrawPosition(board.Width / 2, board.Height / 2, "GAME OVER");
Utils.DrawPosition(board.Width / 2, board.Height / 2, $"Score: {snake.Score}");

Console.WriteLine("Press any key to finish");
Console.ReadKey();
Console.Clear();

Direction ReadMovement(Direction actualDirection)
{
    if (!Console.KeyAvailable) return actualDirection;
    
    var key = Console.ReadKey().Key;

    switch (key)
    {
        case ConsoleKey.UpArrow when actualDirection != Direction.Down:
            return Direction.Up;
        case ConsoleKey.DownArrow when actualDirection != Direction.Up:
            return Direction.Down;
        case ConsoleKey.LeftArrow when actualDirection != Direction.Right:
            return Direction.Left;
        case ConsoleKey.RightArrow when actualDirection != Direction.Left:
            return Direction.Right;
        default:
            return actualDirection;
    }
}
