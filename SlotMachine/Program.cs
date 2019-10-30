using SlotMachine.Logic;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInteractions userInteractions = new UserInteractions();
            var controller = new ControllerFactory().CreateController();

            var gameEngine = new GameEngine(userInteractions, controller);
            gameEngine.StartGame();
        }
    }
}
