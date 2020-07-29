using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UltimateTicTacToe.WebUI.Models.Game;

namespace UltimateTicTacToe.WebUI.Components
{
    public partial class Field
    {

        [Parameter] 
        public FieldModel FieldModel { get; set; } = new FieldModel();

        [Parameter]
        public Position FieldPosition { get; set; } = new Position(0,0);
        
        [Parameter]
        public bool Interactable { get; set; } = true;

        [Parameter]
        public bool HighlightMove { get; set; } = false;

        [Parameter]
        public Position HighlightMovePosition { get; set; } = new Position();


        public void OnClick(int x, int y)
        {
            SuperFieldState.DoMove(new SquarePosition(FieldPosition, new Position(x,y)));
        }

        public string GetSquareCssClasses(int x, int y)
        {
            SquareState square = FieldModel.Squares[y][x];

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
            if (square == SquareState.O)
            {
                return css + " player1";

            }
            else if (square == SquareState.X)
            {
                return css + " player2";
            }
            else
            {
                if (Interactable)
                {
                    return css + " yellow interactive";
                }
                else
                {
                    return css;
                }
            }
        }

    }
}
