using System;
using System.Collections.Generic;

namespace HepsiBurada.Simulator.Model
{
    public class CommandProto
    {
        public CommandType CommandType { get; set; }
        public IList<string> Parameters { get; set; }
    }
}