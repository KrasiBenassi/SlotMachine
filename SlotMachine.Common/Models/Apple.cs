﻿namespace SlotMachine.Common.Models
{
    public class Apple : Symbol
    {
        public override char Sign => 'A';

        public override double Coefficient => 0.4;

        public override int Probability => 45;
    }
}
