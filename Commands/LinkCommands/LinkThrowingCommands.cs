using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class ThrowCommand : ICommand
    {
        public ThrowCommand()
        { 
        }
        public void Execute()
        {
            Link.Instance.ThrowProjectile();
        }
    }
 
}






