using SlotMachine.Common.Models;

namespace SlotMachine.Logic
{
    public interface IController
    {
        bool NewGame(decimal deposit);

        SpinResult Spin(decimal amount);

        bool PlayerStatus();
    }
}
