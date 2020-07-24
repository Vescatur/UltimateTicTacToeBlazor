using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateTicTacToe.Models.Game
{
    public class FieldModel
    {
        public SquareState[][] Squares { get; set; } = {
           new SquareState[3],
           new SquareState[3],
           new SquareState[3]
        };

        public FieldState Winner;

        public FieldModel(FieldModel fieldModel)
        {
            for(int y=0; y<3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Squares[y][x] = fieldModel.Squares[y][x];
                }
            }
            Winner = fieldModel.Winner;
        }

        public FieldModel()
        {
        }
    }
}
