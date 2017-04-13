using System;

namespace SolidPrinciples.LSP.Example2
{
    public class OutOfFuelException : Exception
    {
        public OutOfFuelException(string message) : base(message)
        {
        }
    }
}
