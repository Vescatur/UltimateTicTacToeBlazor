using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateTicTacToe.WebUI.Models.Game;
using UltimateTicTacToe.WebUI.State;

namespace UltimateTicTacToe.WebUI.Components
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
