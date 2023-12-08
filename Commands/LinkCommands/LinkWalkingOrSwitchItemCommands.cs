using GameStates;
using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Commands
{
    public class WalkRightCommand : ICommand
    {
        private GameStateController controller;
        public WalkRightCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
            if (controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                if (oldRect.X < 400+oldRect.Width*5)
                {
                   inventory.cursor.DestinationRectangle = new(oldRect.X + oldRect.Width, oldRect.Y, oldRect.Width, oldRect.Height);
                }
            }
            else
            {
                Link.Instance.MoveRight();
            }
        }
    }

    public class WalkLeftCommand : ICommand
    {
        private GameStateController controller;
        public WalkLeftCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                if (oldRect.X > 400)
                {
                    inventory.cursor.DestinationRectangle = new(oldRect.X - oldRect.Width, oldRect.Y, oldRect.Width, oldRect.Height);
                }
            }
            else
            {
                Link.Instance.MoveLeft();
            }
        }
    }

    public class WalkUpCommand : ICommand
    {
        private GameStateController controller;
        public WalkUpCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                
                if (oldRect.Y > 122 )
                {
                    inventory.cursor.DestinationRectangle = new(oldRect.X, oldRect.Y - oldRect.Height, oldRect.Width, oldRect.Height);
                }
            }
            else
            {
                Link.Instance.UpdatePosition();
                Link.Instance.MoveUp();
            }
        }
    }

    public class WalkDownCommand : ICommand
    {
        private GameStateController controller;
        public WalkDownCommand(GameStateController controller)
        {
             this.controller = controller;
        }
        public void Execute()
        {
            if (this.controller.gameState is InventoryState)
            {
                var inventory = controller.gameState as InventoryState;
                var oldRect = inventory.cursor.DestinationRectangle;
                if (oldRect.Y < 122 + (oldRect.Height))
                {
                    inventory.cursor.DestinationRectangle = new(oldRect.X, oldRect.Y + oldRect.Height, oldRect.Width, oldRect.Height);
                }
            }
            else
            {
                Link.Instance.MoveDown();
            }
        }
    }
}

