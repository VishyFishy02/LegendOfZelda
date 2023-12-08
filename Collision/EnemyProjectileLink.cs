using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda;
using Sprites;
using System.Diagnostics;
using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Collision
{
    public static class EnemyProjectileLinkHandler
	{		

		public static void handleCollision(IEnemyProjectile projectile,string side, Room room)
		{
            // have the projectile set it's currFrame to its last frame of animation
            projectile.collide();
            Link.Instance.TakeDamage(side);
			room.RemoveObject(projectile);
		}
	}
}
