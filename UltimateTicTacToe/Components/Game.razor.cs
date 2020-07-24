using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateTicTacToe.Models.Game;
using UltimateTicTacToe.State;

namespace UltimateTicTacToe.Components
{
    public partial class Game : IDisposable
    {

        public SuperFieldModel SuperFieldModel = new SuperFieldModel();
        private void OnStateChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            SuperFieldModel = SuperFieldState.GetSuperField();
            SuperFieldState.StateChanged += OnStateChanged;
        }

        void IDisposable.Dispose()
        {
            SuperFieldState.StateChanged -= OnStateChanged;
        }

    }
}
