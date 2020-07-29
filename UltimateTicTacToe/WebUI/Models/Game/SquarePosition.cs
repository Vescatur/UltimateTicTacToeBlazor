using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateTicTacToe.WebUI.Models.Game
{
    public struct SquarePosition
    {
        public Position Field {get;set; }
        public Position Square { get; set; }

        public SquarePosition(int fieldX, int fieldY, int squareX, int squareY)
        {
            Field = new Position(fieldX,fieldY);
            Square = new Position(squareX, squareY);
        }
        public SquarePosition(Position field, Position square)
        {
            Field = field;
            Square = square;
        }
        
        public override string ToString()
        {
            return Field.X + " " + Field.Y + " " + Square.X + " " + Field.Y;
        }

        public static bool operator ==(SquarePosition c1, SquarePosition c2)
        {
            return c1.Field == c2.Field && c1.Square == c2.Square;
        }
        public static bool operator !=(SquarePosition c1, SquarePosition c2)
        {
            return !(c1 == c2);
        }
    }
}
