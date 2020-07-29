using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateTicTacToe.WebUI.Models.Game
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position c1, Position c2)
        {
            return c1.X == c2.X && c1.Y == c2.Y;
        }
        public static bool operator !=(Position c1, Position c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
