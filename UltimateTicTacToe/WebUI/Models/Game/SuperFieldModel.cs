

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateTicTacToe.WebUI.Models.Game
{
    public class SuperFieldModel
    {
        public SquareState PlayersTurn = SquareState.X;

        public bool TurnRestrictedToField = false;
        public Position RestrictedToFieldPosition = new Position(0, 0);

        public bool HighlightMove = false;
        public SquarePosition HighlightMovePosition = new SquarePosition(0,0,0,0);

        public FieldModel[][] Fields { get; set; } = {
           new FieldModel[] { new FieldModel(),new FieldModel(),new FieldModel()},
           new FieldModel[] { new FieldModel(),new FieldModel(),new FieldModel()},
           new FieldModel[] { new FieldModel(),new FieldModel(),new FieldModel()}
        };

        public FieldState Winner;

        public SuperFieldModel()
        {

        }

        public SuperFieldModel(SuperFieldModel superField)
        {
            Winner = superField.Winner;

            PlayersTurn = superField.PlayersTurn;

            TurnRestrictedToField = superField.TurnRestrictedToField;
            RestrictedToFieldPosition = superField.RestrictedToFieldPosition;

            HighlightMove = superField.HighlightMove;
            HighlightMovePosition = superField.HighlightMovePosition;

            Fields = new FieldModel[][]{
                new FieldModel[] { new FieldModel(superField.Fields[0][0]), new FieldModel(superField.Fields[0][1]), new FieldModel(superField.Fields[0][2]) },
                new FieldModel[] { new FieldModel(superField.Fields[1][0]), new FieldModel(superField.Fields[1][1]), new FieldModel(superField.Fields[1][2]) },
                new FieldModel[] { new FieldModel(superField.Fields[2][0]), new FieldModel(superField.Fields[2][1]), new FieldModel(superField.Fields[2][2]) }
            };
        }
    }
}
