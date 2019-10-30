using SlotMachine.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Logic
{
    internal interface ISlotMachine
    {
        SpinResult Spin(decimal amount);
    }
}
