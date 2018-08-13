using System;

namespace EqualExpertsAutomationProject.UserDefinedExceptions
{
    public class InvalidDriverException : Exception
    {
        //InvalidDriverException classed will be used supply exception messaage for invaild browser types.
        public InvalidDriverException()
        {
        }

        public InvalidDriverException(string message) : base(message)
        {
        }


    }
}

