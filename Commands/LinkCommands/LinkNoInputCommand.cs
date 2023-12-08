using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class NoInputCommand : ICommand
    {
        public NoInputCommand()
        {
        }
        public void Execute()
        {
            Link.Instance.NoInput();
        }
    }
}