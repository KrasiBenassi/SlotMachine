using SlotMachine.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.Logic
{
    internal class CoefficientCalculator : ICoefficientCalculator
    {
        public double CalculateCoefficient(List<Symbol> symbols)
        {
            var tempSymbols = new List<Symbol>(symbols);

            tempSymbols.RemoveAll(s => s is WildCard);
            double coefficient = 0;

            if (!tempSymbols.Distinct().Skip(1).Any())
            {
                foreach (var symbol in tempSymbols)
                {
                    coefficient += symbol.Coefficient;
                }
            }

            return coefficient;
        }
    }
}
