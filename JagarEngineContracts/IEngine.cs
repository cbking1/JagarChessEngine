using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IEngine
    {
        string Name { get; }
        string Version { get; }

        IEnumerable<string> GetOptions();
        void WaitUntilready();

        void Play(IMove move);

        IMove MakeBestMove();
    }
}
