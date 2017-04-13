using System;

namespace SolidPrinciples.LSP.Example2
{
    public class YouAreDeadException : Exception
    {
        public YouAreDeadException(string message) : base(message)
        {
        }
    }
}
