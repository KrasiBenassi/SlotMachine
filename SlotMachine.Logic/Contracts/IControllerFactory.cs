using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Logic
{
    public interface IControllerFactory
    {
        IController CreateController();
    }
}
