using SlotMachine.Common.Models;
using System.Collections.Generic;

namespace SlotMachine
{
    public interface IUserInteractions
    {
        decimal RequestDeposit();

        decimal RequestBet();

        bool RequestNewGame();

        void DrawBord(List<List<Symbol>> symbolsGrid);
    }
}
