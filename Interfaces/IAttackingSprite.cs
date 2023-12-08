using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
namespace LegendofZelda.Interfaces
{
    public interface IAttackingSprite : ISprite
    {
        bool isAttacking();
        string getSide();
    }
}
