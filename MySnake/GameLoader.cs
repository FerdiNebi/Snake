using System;
using System.Linq;

namespace MySnake
{
    /// <summary>
    /// Initializes objects and starts the game.
    /// </summary>
    class GameLoader
    {
        private const int WorldWidth = 30;
        private const int WorldHeight = 15;
        private static Random randGenerator = new Random();

        static void Main(string[] args)
        {
            Snake mySnake = new Snake(new Vector { X = 3, Y = 10 }, new Vector { X = 1, Y = 0 });
            Food food = new Food(new Vector { X = randGenerator.Next(1,WorldWidth), Y = randGenerator.Next(1,WorldHeight) });
            ConsoleRenderer renderer = new ConsoleRenderer(WorldWidth, WorldHeight);
            Keyboard keyboard = new Keyboard();
            
            keyboard.OnLeftKeyPressed += (sender, eventInfo) =>
            {
                mySnake.ChangeDirection(new Vector { X = -1, Y = 0 });
            };
            keyboard.OnUpKeyPressed += (sender, eventInfo) =>
            {
                mySnake.ChangeDirection(new Vector { X = 0, Y = -1 });
            };
            keyboard.OnRightKeyPressed += (sender, eventInfo) =>
            {
                mySnake.ChangeDirection(new Vector { X = 1, Y = 0 });
            };
            keyboard.OnDownKeyPressed += (sender, eventInfo) =>
            {
                mySnake.ChangeDirection(new Vector { X = 0, Y = 1 });
            };

            GameEngine gameEngine = new GameEngine(mySnake, keyboard,food, renderer,WorldWidth,WorldHeight);
            gameEngine.Run();
        }
    }
}