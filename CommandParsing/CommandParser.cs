﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using JagarEngineContracts;
using Commands;
using ChessEngineContracts;

namespace CommandParsing
{
    public class CommandParser : ICommandParser
    {

        public ConcurrentQueue<IUciInputCommand> InputQueue { get; private set; }
        private readonly IMoveParser _moveParser;

        public CommandParser(IMoveParser moveParser)
        {
            _moveParser = moveParser;
            InputQueue = new ConcurrentQueue<IUciInputCommand>();
        }

        public void StartParsing()
        {
            bool exit = false;
            while (!exit)
            {
                string commandString = Console.ReadLine();
                IUciInputCommand command = ParseLine(commandString);
            }
        }

        private IUciInputCommand ParseLine(string commandString)
        {
            List<string> parameters = commandString.Split(' ').ToList();
            while (parameters.Any())
            {
                switch (parameters.First())
                {
                    case "uci":
                        return new UciInputCommand();
                    case "debug":
                        bool debugOn;
                        parameters.RemoveAt(0);
                        try
                        {
                            debugOn = ParseDebugOn(parameters);
                        }
                        catch (ArgumentException ex)
                        {
                            throw new ArgumentException("Unable to parse Debug command, expected syntax is debug [ on | off ]", ex);
                        }
                        
                        return new DebugCommand(debugOn);
                    case "isready":
                        return new IsReadyCommand();
                    case "register":
                        return new RegisterCommand();
                    case "ucinewgame":
                        return new UciNewGameCommand();
                    case "position":
                        parameters.RemoveAt(0);
                        var arguments = ParsePositionArguments(parameters);
                        return new PositionCommand(arguments.Item1, arguments.Item2);
                    case "go":
                        parameters.RemoveAt(0);
                        IGoArguments goArguments = ParseGoArguments(parameters);
                }
                parameters.RemoveAt(0);
            }
            return new NullInputCommand();
        }

        private IGoArguments ParseGoArguments(List<string> parameters)
        {
            IGoArguments goArguments = new GoArguments();
            while (parameters.Any())
            {
                switch (parameters.First())
                {
                    case "searchmoves":
                        parameters.RemoveAt(0);
                        while (parameters.Any())
                        {
                            if (_moveParser.IsMove(parameters.First()))
                            {
                                goArguments.SearchMoves.Add(_moveParser.LastParsedMove);
                            }

                        }
                }
            }
        }

        private Tuple<string, IEnumerable<IMove>> ParsePositionArguments(List<string> parameters)
        {
            string fen;
            try
            {
                switch (parameters.First())
                {
                    case "fen":
                        parameters.RemoveAt(0);
                        fen = parameters.First();
                        parameters.RemoveAt(0);
                        break;
                    case "startpos":
                        parameters.RemoveAt(0);
                        fen = "";
                        break;
                    default:
                        throw new ArgumentException("Cannot parse arguments for position command. Expected syntax is position [fen <fenstring> | startpos ]  moves <move1> .... <movei>");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentException("Cannot parse arguments for position command. Expected syntax is position [fen <fenstring> | startpos ]  moves <move1> .... <movei>", ex);
            }
            IEnumerable<IMove> moves = _moveParser.ParseMoves(parameters);
            return new Tuple<string, IEnumerable<IMove>>(fen, moves);
        }

        private bool ParseDebugOn(List<string> parameters)
        {
            if (!parameters.Any())
            {
                throw new ArgumentException("The string cannot be parsed as a debugString. Acepted values are 'on' and 'off'");
            }
            switch (parameters.First())
            {
                case "on":
                    return true;
                case "off":
                    return false;
                default:
                    throw new ArgumentException("The string cannot be parsed as a debugString. Acepted values are 'on' and 'off'");
            }

        }
    }
}
