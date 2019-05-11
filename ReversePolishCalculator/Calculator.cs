using EnsureThat;
using System;

namespace ReversePolishCalculator
{
    public class Calculator
    {     
        public virtual decimal Add(decimal first, decimal second)
        {  return first + second; }

        public virtual decimal Subtract(decimal first, decimal second)
        { return first - second; }

        public virtual decimal Multiply(decimal first, decimal second)
        { return first * second; }

        public virtual decimal Divide(decimal first, decimal second)
        {
            Ensure.That(second, nameof(second)).IsNot(0);
            return first / second;
        }

        public virtual decimal Power(decimal first, decimal second)
        { return (decimal)Math.Pow((double)first, (double)second); }       
    }
}
