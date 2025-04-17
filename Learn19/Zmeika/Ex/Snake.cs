using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    class Snake
    {
        public List<Position> Body { get; private set; }
        public int Dx { get; set; }
        public int Dy { get; set; }

        public Snake(int startX, int startY)
        {
            Body = new List<Position> { new Position(startX, startY) };
            Dx = 1; Dy = 0;
        }

        public void Move()
        {
            Position newHead = new Position(Body[0].X + Dx, Body[0].Y + Dy);
            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            Body.Add(new Position(Body[Body.Count - 1].X, Body[Body.Count - 1].Y));
        }

        public bool CollidesWithSelf()
        {
            for (int i = 1; i < Body.Count; i++)
                if (Body[i].X == Body[0].X && Body[i].Y == Body[0].Y)
                    return true;
            return false;
        }

        public bool CollidesWithWall(int width, int height)
        {
            return Body[0].X < 0 || Body[0].X >= width || Body[0].Y < 0 || Body[0].Y >= height;
        }

        public Position GetHead()
        {
            return Body[0];
        }
    }
}
