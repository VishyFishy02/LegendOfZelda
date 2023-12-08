using Microsoft.Xna.Framework.Graphics;

namespace LegendofZelda.Interfaces
{
    public interface IEnemy:ISprite
    {
        void TakeDamage(string side);
        void TurnAround(string side);
        public bool IsDead { get; set; }
        public bool DyingComplete { get; set; }
        ISprite DropItem();
        
    }
}
