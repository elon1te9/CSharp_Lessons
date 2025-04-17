using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex
{
    class Game
    {
        private int Width = 20, Height = 10;
        private Snake snake;
        private Food food;
        private bool gameOver;
        private int score;

        public void Run()
        {
            snake = new Snake(Width / 2, Height / 2);
            food = new Food();
            food.Generate(Width, Height, snake.Body);

            while (!gameOver)
            {
                Draw();
                Input();
                Update();
                Thread.Sleep(200);
            }
            GameOver();
        }

        private void Draw()
        {
            Console.SetCursorPosition(0, 0); 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (snake.Body.Exists(p => p.X == x && p.Y == y))
                        Console.Write("■"); 
                    else if (food.position.X == x && food.position.Y == y)
                        Console.Write("X"); 
                    else
                        Console.Write("░");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Score: {score}");
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && snake.Dy == 0) { snake.Dx = 0; snake.Dy = -1; }
                if (key == ConsoleKey.DownArrow && snake.Dy == 0) { snake.Dx = 0; snake.Dy = 1; }
                if (key == ConsoleKey.LeftArrow && snake.Dx == 0) { snake.Dx = -1; snake.Dy = 0; }
                if (key == ConsoleKey.RightArrow && snake.Dx == 0) { snake.Dx = 1; snake.Dy = 0; }
            }
        }

        private void Update()
        {
            snake.Move();
            if (snake.CollidesWithSelf() || snake.CollidesWithWall(Width, Height))
                gameOver = true;
            if (snake.GetHead().X == food.position.X && snake.GetHead().Y == food.position.Y)
            {
                snake.Grow();
                food.Generate(Width, Height, snake.Body);
                score++;
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over! Score: " + score);
        }
    }
}
