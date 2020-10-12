using System.Collections.Generic;

namespace ShoppingCart.Commands
{
    public class CommandManager
    {
        // some ideas
        // execute commands at a later time
        // save all commands to re-execute later together 
        private Stack<ICommand> _commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            _commands.Push(command);
            command.Execute(); 
        }

        public void Undo()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo(); 
            }
        }

    }
}
