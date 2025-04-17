using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    class Food
    {
        public Position position { get; private set; }
        private Random rnd = new Random();

        public void Generate(int width, int height, List<Position> snakeBody)
        {
            int x, y;
            do
            {
                x = rnd.Next(0, width);
                y = rnd.Next(0, height);
            } while (snakeBody.Exists(p => p.X == x && p.Y == y));
            position = new Position(x, y);
        }
    }
}
