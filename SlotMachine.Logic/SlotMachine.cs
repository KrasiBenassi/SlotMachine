using SlotMachine.Common.Models;
using System.Collections.Generic;

namespace SlotMachine.Logic
{
    internal class SlotMachine : ISlotMachine
    {
        private const int ROW_NUMBER = 3;
        private const int COLUMN_NUMBER = 4;

        private readonly Player m_Player;
        private readonly ISymbolGenerator m_SymbolGenerator;
        private readonly ICoefficientCalculator m_CoefficientCalculator;

        public SlotMachine(
            Player player, 
            ISymbolGenerator symbolGenerator, 
            ICoefficientCalculator coefficientCalculator)
        {
            m_Player = player;
            m_SymbolGenerator = symbolGenerator;
            m_CoefficientCalculator = coefficientCalculator;
        }

        public SpinResult Spin(decimal amount)
        {
            var symbolsGrid = new List<List<Symbol>>();
            double winCoefficient = 0;

            for (int i = 0; i < COLUMN_NUMBER; i++)
            {
                List<Symbol> symbols = m_SymbolGenerator.GenerateSymbols(ROW_NUMBER);
                symbolsGrid.Add(symbols);
                winCoefficient += m_CoefficientCalculator.CalculateCoefficient(symbols);
            }

            var winValue = (decimal)winCoefficient * amount;
            m_Player.Balance += winValue;
            var spinResult = new SpinResult(symbolsGrid, winValue, m_Player.Balance, true);

            return spinResult;
        }
    }
}
