using System;
using System.Collections.Generic;
using System.Linq;
using HepsiBurada.Simulator.Model;

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

        public (CommandType, IList<string>) GetCommand()
        {
            var parsedLine = ParseLine();
            if (Enum.TryParse(parsedLine[0], out CommandType commandType))
            {
                return (commandType, parsedLine.Skip(1).Take(parsedLine.Count -1).ToArray());
            }
            throw new InvalidOperationException($"Invalid Commmand at line:{_lineNumber}");
        }

        private IList<string> ParseLine()
        {
            if (string.IsNullOrWhiteSpace(_line))
            {
                throw new InvalidOperationException($"Empty line at line:{_lineNumber}");
            }

            var parsedLine = _line.Split(" ");

            if (parsedLine is null || parsedLine.Length < 2)
            {
                throw new InvalidOperationException($"Syntax error at line:{_lineNumber}");
            }

            return parsedLine;
        }
    }
}