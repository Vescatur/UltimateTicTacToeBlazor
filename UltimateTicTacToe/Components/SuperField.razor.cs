using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UltimateTicTacToe.Models.Game;

namespace UltimateTicTacToe.Components
{
    public partial class SuperField
    {
        [Parameter]
        public SuperFieldModel SuperFieldModel { get; set; } = new SuperFieldModel();

        public bool HighlightMove(int x, int y)
        {
            if (SuperFieldModel.HighlightMove)
            {
                var pos = SuperFieldModel.HighlightMovePosition.Field;
                if (SuperFieldModel.Fields[pos.Y][pos.X].Winner == FieldState.None)
                {
                    if (pos == new Position(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Interactable(int x, int y)
        {
            if (SuperFieldModel.Winner == FieldState.None)
            {
                if (!SuperFieldModel.TurnRestrictedToField)
                {
                    return true;
                }

                if (SuperFieldModel.RestrictedToFieldPosition == new Position(x, y))
                {
                    return true;
                }
            }

            return false;
        }

        public string GetFieldCssClasses(int x, int y)
        {
            var field = SuperFieldModel.Fields[y][x];
            var css = "";
            if (y == 0)
            {
                css += "top";
            }
            if (y == 1)
            {
                css += "middle";
            }
            if (y == 2)
            {
                css += "bottom";
            }
            if (x == 0)
            {
                css += " left";
            }
            if (x == 1)
            {
                css += " center";
            }
            if (x == 2)
            {
                css += " right";
            }


            if (field.Winner == FieldState.O)
            {
                return css + " player1";

            }
            else if (field.Winner == FieldState.X)
            {
                return css + " player2";
            }
            return css;
        }


    }
}
