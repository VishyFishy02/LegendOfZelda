using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class SwitchToBombCommand : ICommand
    {
        public SwitchToBombCommand()
        {
        }
        public void Execute()
        {
            if (Link.Instance.inventory.getItemCount("bomb") > 0)
            {
                Link.Instance.throwable = Link.Throwables.Bomb;
            }
        }
    }

    public class SwitchToBoomerangCommand : ICommand
    {
        public SwitchToBoomerangCommand()
        { 
        }
        public void Execute()
        {
            if (Link.Instance.inventory.getItemCount("boomerang") > 0)
            {
                Link.Instance.throwable = Link.Throwables.Boomerang;
            }
        }
    }

    public class SwitchToBlueBoomerangCommand : ICommand
    {
        public SwitchToBlueBoomerangCommand()
        {
        }
        public void Execute()
        {
            if (Link.Instance.inventory.getItemCount("boomerang") > 0)
            {
                Link.Instance.throwable = Link.Throwables.BlueBoomerang;
            }
        }
    }

    public class SwitchToArrowCommand : ICommand
    {
        public SwitchToArrowCommand()
        {
        }
        public void Execute()
        {
            if (Link.Instance.inventory.getItemCount("bow") == 1)
            {
                Link.Instance.throwable = Link.Throwables.Arrow;
            }
        }
    }
    public class SwitchToBlueArrowCommand : ICommand
    {
        public SwitchToBlueArrowCommand()
        {  
        }
        public void Execute()
        {
            if (Link.Instance.inventory.getItemCount("bow") == 1)
            {
                Link.Instance.throwable = Link.Throwables.BlueArrow;
            }
        }
    }

    public class SwitchToFireCommand : ICommand
    {
        public SwitchToFireCommand()
        {  
        }
        public void Execute()
        {
            Link.Instance.throwable = Link.Throwables.Fire;
        }
    }
}
