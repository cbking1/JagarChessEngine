using System;
using System.Collections.Generic;
using System.Text;
using Contracts;

namespace Engine
{
    public class ChessEngine : IEngine
    {
        private const string EngineName = "JagarChess";
        private const string EngineVersion = "1.0";
        public string Name => EngineName;

        public string Version => EngineVersion;

        public IEnumerable<string> GetOptions()
        {
            return new List<string> { "Hash type spin default 1 min 1 max 1" };
        }

        public void WaitUntilready()
        {
            return;
        }
    }
}
