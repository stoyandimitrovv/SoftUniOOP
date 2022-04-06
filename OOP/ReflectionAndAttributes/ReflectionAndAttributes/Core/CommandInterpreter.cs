﻿using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = input[0] + "Command";

            string[] value = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(value);

            return result;
        }
    }
}
