using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day08
{
    public class Program
    {
        private readonly List<Command> _commands;

        public Program(IEnumerable<string> data)
        {
            _commands = data.Select(x =>
            {
                var split = x.Split();
                return new Command(split[0], int.Parse((string) split[1]));
            }).ToList();
        }

        public int Run()
        {
            Reset();

            var accumulator = 0;
            var commandLine = 0;

            while (commandLine < _commands.Count)
            {
                var command = _commands[commandLine];
                if (command.IsExecuted)
                    throw new InfiniteLoopException { Accumulator = accumulator };

                switch (command.Operation)
                {
                    case "acc":
                        accumulator += command.Argument;
                        commandLine++;
                        break;
                    case "jmp":
                        commandLine += command.Argument;
                        break;
                    case "nop":
                        commandLine++;
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown command: {command.Operation}");
                }

                command.IsExecuted = true;
            }

            return accumulator;
        }

        private void Reset()
        {
            _commands.ForEach(c => c.IsExecuted = false);
        }

        public int RunWithSelfHealing()
        {
            var commandLine = 0;
            var accumulator = -1;

            while (accumulator == -1)
            {
                try
                {
                    if (SwitchCommand(commandLine)) 
                        accumulator = Run();
                }
                catch (InfiniteLoopException)
                {
                    SwitchCommand(commandLine);
                }
                commandLine++;
            }

            return accumulator;
        }
        
        private bool SwitchCommand(int commandLine)
        {
            return _commands[commandLine].Switch();
        }
    }
}