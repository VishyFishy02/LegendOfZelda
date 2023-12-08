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
using LegendofZelda.EnemyAndNPCSprites;

namespace Collision
{
    public static class EnemyProjectileBlockHandler
	{		
		static EnemyProjectileBlockHandler()
		{
			
		}
		public static void handleCollision(IEnemyProjectile projectile, Room room)
		{
			projectile.collide();
			if (projectile is BottomDragonAttackOrbSprite || projectile is TopDragonAttackOrbSprite || projectile is MiddleDragonAttackOrbSprite)
			{
				room.RemoveObject(projectile);
			}
		}        
	}
}
