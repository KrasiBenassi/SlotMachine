using SlotMachine.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.Logic
{
    internal class SymbolGenerator : ISymbolGenerator
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private Random m_RandomGenerator;
        private List<Symbol> m_Symbols;

        public SymbolGenerator()
        {
            m_RandomGenerator = new Random();
            LoadSymbols();
        }

        public List<Symbol> GenerateSymbols(int numberOfSymbols)
        {
            var result = new List<Symbol>();

            for (int i = 0; i < numberOfSymbols; i++)
            {
                var randomNumber = m_RandomGenerator.Next(MIN_VALUE, MAX_VALUE);
                int currentProbability = 0;
                for (int j = 0; j < m_Symbols.Count; j++)
                {
                    currentProbability += m_Symbols[j].Probability;
                    if (randomNumber <= currentProbability)
                    {
                        result.Add(m_Symbols[j]);
                        break;
                    }
                }
            }

            return result;
        }

        private void LoadSymbols()
        {
            m_Symbols = new List<Symbol>
            {
                new Apple(),
                new Banana(),
                new Pineapple(),
                new WildCard()
            }.OrderBy(s => s.Probability).ToList();
        }
    }
}
