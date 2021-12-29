using FizzBuzz.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Tests.Fakes
{
    public class FakeConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Result += input;
        }
        public string Result { get; set; }
    }
}
