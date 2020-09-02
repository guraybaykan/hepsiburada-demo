using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HepsiBurada.Simulator
{
    public class CommandBuilder
    {
        private readonly string _line;
        private int _lineNumber;
        public CommandBuilder(string line, int lineNumber)
        {
            _line = line;
            _lineNumber = lineNumber;
        }

        public void GetCommand()
        {
            var parsedLine = ParseLine();
            if(Enum.TryParse(parsedLine[0], out CommandType commandType))
            {

            }
            else
            {
                System.Console.WriteLine($"err -> {commandType}");
            }
        }

        private IList<string> ParseLine()
        {
            if(string.IsNullOrWhiteSpace(_line))
            {
                throw new InvalidCastException($"Empty line at line:{_lineNumber}");
            }

            var parsedLine = _line.Split(" ");

            if(parsedLine is null || parsedLine.Length < 2)
            {
                throw new InvalidCastException($"Syntax error at line:{_lineNumber}");
            }

            return parsedLine;
        }
    }
}