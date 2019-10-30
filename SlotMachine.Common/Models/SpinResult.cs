using System.Collections.Generic;

namespace SlotMachine.Common.Models
{
    public class SpinResult
    {
        public SpinResult(
            List<List<Symbol>> symbols, 
            decimal winAmount, 
            decimal balance, 
            bool isSuccess)
        {
            Symbols = symbols;
            WinAmount = winAmount;
            Balance = balance;
            IsSuccess = isSuccess;
        }

        public List<List<Symbol>> Symbols { get; set; }

        public decimal WinAmount { get; set; }

        public decimal Balance { get; set; }

        public bool IsSuccess { get; set; }
    }
}