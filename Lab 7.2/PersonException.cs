using System;
using System.Runtime.Serialization;

namespace Lab_7._2
{
    public class Exceptions
    {
        public class DeleteItemException : Exception
        {
            public DeleteItemException(string message) : base(message) { }
        }
        public class Zero : Exception
        {
            public Zero(string message) : base(message) { }
        }
        public class PersonException : ArgumentException
        {
            public int Value { get; }
            public PersonException(string message, int val) : base(message)
            {
                Value = val;
            }
        }
        public class StringException : ArgumentException
        {
            public string Value { get; }
            public StringException(string message, string val) : base(message)
            {
                Value = val;
            }
        }
        public class NoVir : Exception
        {
            public NoVir(string message) : base(message) { }
        }
    }

}