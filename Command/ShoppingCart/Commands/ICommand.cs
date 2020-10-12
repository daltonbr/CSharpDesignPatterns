namespace ShoppingCart.Commands
{
    public interface ICommand
    {
        public void Execute();
        public bool CanExecute();
        public void Undo();
    }
}
