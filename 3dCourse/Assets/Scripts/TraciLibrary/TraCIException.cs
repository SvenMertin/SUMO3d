using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TraciConnector
{
    public class TraCIException : IOException
    {
        public TraCIException(): base ()
        {
        }

        public TraCIException(string msg): base (msg)
        {
        }

        public class UnexpectedData : TraCIException
        {
            public UnexpectedData(string what, Object expected, Object got): base ("Unexpected " + what + ": expected " + expected + ", got " + got)
            {
            }
        }

        public class UnexpectedDatatype : UnexpectedData
        {
            public UnexpectedDatatype(int expected, int got): base ("datatype", expected, got)
            {
            }
        }

        public class UnexpectedResponse : UnexpectedData
        {
            public UnexpectedResponse(int expected, int got): base ("response", expected, got)
            {
            }
        }
    }
}