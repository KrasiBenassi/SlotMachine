using System;

namespace SlotMachine.Common.Models
{
    public class Player
    {
        private decimal m_Balance;

        public decimal Balance
        {
            get { return m_Balance; }
            set { m_Balance = Math.Round(value, 2); }
        }
    }
}
