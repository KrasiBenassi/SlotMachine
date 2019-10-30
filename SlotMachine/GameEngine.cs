using SlotMachine.Logic;
using System;

namespace SlotMachine
{
    public class GameEngine
    {
        private readonly IController m_Controller;
        private readonly IUserInteractions m_UserInteractions;

        public GameEngine(IUserInteractions userInteractions, IController controller)
        {
            m_UserInteractions = userInteractions;
            m_Controller = controller;
        }

        public void StartGame()
        {
            CreateGame();
            PlayGame();
        }

        private void CreateGame()
        {
            decimal deposit = m_UserInteractions.RequestDeposit();
            m_Controller.NewGame(deposit);
        }

        private void PlayGame()
        {
            while (true)
            {
                decimal bet = m_UserInteractions.RequestBet();
                var spinResult = m_Controller.Spin(bet);

                if (!spinResult.IsSuccess)
                {
                    if (spinResult.Balance <= 0)
                    {
                        Console.WriteLine("You lose all your money.");
                        return;
                    }

                    Console.WriteLine($"Your bet more than you have. Your balance is {spinResult.Balance}.");
                }
                else
                {
                    m_UserInteractions.DrawBord(spinResult.Symbols);

                    Console.WriteLine($"You have won: {spinResult.WinAmount}");
                    Console.WriteLine($"Current balance is: {spinResult.Balance}");
                }

                if (!m_Controller.PlayerStatus()) //Cheks if the current player has money.
                {
                    var playerChoice = m_UserInteractions.RequestNewGame();

                    if (playerChoice)
                    {
                        CreateGame();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
