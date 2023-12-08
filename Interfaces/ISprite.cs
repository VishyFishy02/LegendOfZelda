using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendofZelda.Interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
        Rectangle GetHitbox();
        public Rectangle DestinationRectangle { get; set; }
    }
}
