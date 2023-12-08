using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Interfaces;

namespace Collision
{
    public static class EnemyBlockHandler
	{
		public static void handleCollision(IEnemy enemy, IBlock block, string side)
		{
           if((enemy is WallMasterSprite || enemy is KeeseSprite) && (block is INonBoundingBlock)) {
                // do nothing
           } else { 
                enemy.TurnAround(side);
          }
        } 
	}
}
