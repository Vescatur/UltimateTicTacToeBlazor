using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateTicTacToe.WebUI.Components;
using UltimateTicTacToe.WebUI.Models.Game;

namespace UltimateTicTacToe.WebUI.State
{
    public class SuperFieldState
    {
        private SuperFieldModel _superField = new SuperFieldModel();
        
        public event EventHandler StateChanged;
        public SuperFieldModel GetSuperField()
        {
            return _superField;
        }

        public void ResetSuperField()
        {
            _superField = new SuperFieldModel();
            StateHasChanged();
        }

        public void DoMove(SquarePosition pos)
        {
            if (IsMovePossible(_superField,pos) == false)
            {
                return;
            }
            _superField.Fields[pos.Field.Y][pos.Field.X].Squares[pos.Square.Y][pos.Square.X] = _superField.PlayersTurn;


            if (HasFieldThreeInARow(_superField.Fields[pos.Field.Y][pos.Field.X]))
            {
                _superField.Fields[pos.Field.Y][pos.Field.X].Winner = SquareStateToFieldState(_superField.PlayersTurn);
                if (HasSuperFieldThreeInARow(_superField))
                {
                    _superField.Winner = SquareStateToFieldState(_superField.PlayersTurn);
                    _superField.HighlightMove = true;
                    _superField.HighlightMovePosition = pos;
                    StateHasChanged();
                    return;
                }
            }
            else
            {
                if (IsFieldFull(_superField.Fields[pos.Field.Y][pos.Field.X]))
                {
                    _superField.Fields[pos.Field.Y][pos.Field.X].Winner = FieldState.Draw;
                }
            }
            if (IsSuperFieldFull(_superField))
            {
                _superField.Winner = FieldState.Draw;
            }

            if (_superField.Fields[pos.Square.Y][pos.Square.X].Winner != FieldState.None)
            {
                _superField.TurnRestrictedToField = false;
            }
            else
            {
                _superField.TurnRestrictedToField = true;
                _superField.RestrictedToFieldPosition = pos.Square;
            }

            _superField.HighlightMove = true;
            _superField.HighlightMovePosition = pos;
            _superField.PlayersTurn = _superField.PlayersTurn == SquareState.O ? SquareState.X : SquareState.O;
            

            StateHasChanged();
        }

        public bool IsMovePossible(SuperFieldModel superField, SquarePosition pos)
        {
            if (superField.Winner != FieldState.None)
                return false;
            if (superField.Fields[pos.Field.Y][pos.Field.X].Winner != FieldState.None)
                return false;

            if (superField.Fields[pos.Field.Y][pos.Field.X].Squares[pos.Square.Y][pos.Square.X] != SquareState.Empty)
                return false;

            if (_superField.TurnRestrictedToField)
            {
                if (_superField.RestrictedToFieldPosition != pos.Field)
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasFieldThreeInARow(FieldModel field)
        {
            foreach (var squareRow in field.Squares)
            {
                if (AreThreeInARow(squareRow[0], squareRow[1], squareRow[2]))
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (AreThreeInARow(field.Squares[0][i], field.Squares[1][i], field.Squares[2][i]))
                    return true;

            }
            if (AreThreeInARow(field.Squares[0][0], field.Squares[1][1], field.Squares[2][2]))
                return true;
            if (AreThreeInARow(field.Squares[2][0], field.Squares[1][1], field.Squares[0][2]))
                return true;

            return false;
        }
        
        private FieldState SquareStateToFieldState(SquareState playersTurn)
        {
            if (playersTurn == SquareState.O)
            {
                return FieldState.O;
            }
            return FieldState.X;
        }

        private bool HasSuperFieldThreeInARow(SuperFieldModel superField)
        {
            foreach (var fieldRow in superField.Fields)
            {
                if (AreThreeInARowField(fieldRow[0], fieldRow[1], fieldRow[2]))
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (AreThreeInARowField(superField.Fields[0][i], superField.Fields[1][i], superField.Fields[2][i]))
                    return true;

            }
            if (AreThreeInARowField(superField.Fields[0][0], superField.Fields[1][1], superField.Fields[2][2]))
                return true;
            if (AreThreeInARowField(superField.Fields[2][0], superField.Fields[1][1], superField.Fields[0][2]))
                return true;

            return false;
        }

        private bool AreThreeInARowField(FieldModel field1, FieldModel field2, FieldModel field3)
        {
            if (field1.Winner == field2.Winner && field2.Winner == field3.Winner)
            {
                if (field1.Winner == FieldState.O || field1.Winner == FieldState.X)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsFieldFull(FieldModel field)
        {
            foreach (var squareRow in field.Squares)
            {
                foreach (var square in squareRow)
                {
                    if (square == SquareState.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsSuperFieldFull(SuperFieldModel superField)
        {
            foreach (var fieldRow in superField.Fields)
            {
                foreach (var field in fieldRow)
                {
                    if (field.Winner == FieldState.None)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool AreThreeInARow(SquareState squareState1, SquareState squareState2, SquareState squareState3)
        {
            if (squareState1 == squareState2 && squareState2 == squareState3)
            {
                if (squareState1 != SquareState.Empty)
                {
                    return true;
                }
            }
            return false;
        }


        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
