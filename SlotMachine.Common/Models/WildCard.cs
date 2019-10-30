namespace SlotMachine.Common.Models
{
    public class WildCard : Symbol
    {
        public override char Sign => '*';

        public override double Coefficient => 0;

        public override int Probability => 5;
    }
}
