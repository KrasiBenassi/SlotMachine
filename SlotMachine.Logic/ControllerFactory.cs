using SlotMachine.Common.Models;

namespace SlotMachine.Logic
{
    public class ControllerFactory : IControllerFactory
    {
        public IController CreateController()
        {
            var player = new Player();
            var coefficientCalculator = new CoefficientCalculator();
            var symbolGenerator = new SymbolGenerator();
            var slotMachine = new SlotMachine(player, symbolGenerator, coefficientCalculator);
            
            return new Controller(slotMachine);
        }
    }
}
