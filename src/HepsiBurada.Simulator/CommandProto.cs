using System;
using System.Collections.Generic;

namespace HepsiBurada.Simulator
{
    public class CommandProto
    {
        public CommandType CommandType { get; set; }
        public IList<string> Parameters { get; set; }
    }
}