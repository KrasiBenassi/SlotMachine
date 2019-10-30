using SlotMachine.Common.Models;

namespace SlotMachine.Logic
{
    internal class Controller : IController
    {
        private ISlotMachine m_SlotMachine;
        private Player m_Player;

        public Controller(ISlotMachine slotMachine)
        {
            m_SlotMachine = slotMachine;
        }

        public bool NewGame(decimal deposit)
        {
            if (deposit <= 0)
            {
                return false;
            }

            m_Player = new Player
            {
                Balance = deposit
            };

            m_SlotMachine = new SlotMachine(m_Player, new SymbolGenerator(), new CoefficientCalculator());

            return true;
        }

        public SpinResult Spin(decimal amount)
        {
            if (m_Player != null && m_Player.Balance > 0 && m_Player.Balance >= amount)
            {
                m_Player.Balance -= amount;
                var spinResult = m_SlotMachine.Spin(amount);

                return spinResult;
            }

            return new SpinResult(null, 0, m_Player.Balance, false);
        }

        public bool PlayerStatus()
        {
            if (m_Player != null && m_Player.Balance > 0)
            {
                return true;
            }

            return false;
        }
    }
}
