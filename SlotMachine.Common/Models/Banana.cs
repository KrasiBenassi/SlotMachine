﻿namespace SlotMachine.Common.Models
{
    public class Banana : Symbol
    {
        public override char Sign => 'B';

        public override double Coefficient => 0.6;

        public override int Probability => 35;
    }
}
