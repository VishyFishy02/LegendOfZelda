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
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkEnemyHandler
	{		
		public static void handleCollision(IEnemy enemy, string side, Game1 game)
		{
			if(Link.Instance.currentLinkSprite is IAttackingSprite)
			{

                IAttackingSprite currLinkSprite = (IAttackingSprite) Link.Instance.currentLinkSprite;
                if (currLinkSprite.getSide() == side)
                {
                    side = reverseSide(side); // flip the side so it is in the perspective of the enemy
                    if (enemy is not GohmaSprite)
                    {
                        enemy.TakeDamage(side);
                    }
                    
                }else
                {
                    Link.Instance.TakeDamage(side);
                }
            } else
			{   
                if(!(Link.Instance.isDamaged))
                {
                    if(enemy is WallMasterSprite)
                {
                    game.currentRoomIndex = 0;
                    game.currentRoom = game.rooms[game.currentRoomIndex];
                } else if(enemy is TrapSprite) {
                    Link.Instance.health = 0f;
                    Link.Instance.Die();
                } else { 
				    Link.Instance.TakeDamage(side);
                }
                }                
            }
        }


        private static string reverseSide(string side)
		{
            // if enemy is to take damage, reverse side so that collision is from their perspective rather than link's
			switch(side)
            {
                 case "top":
                      return "bottom";
                 case "bottom":
                      return "top";
                 case "left":
                      return "right";    
                 case "right":
                      return "left"; 
                 default:
                      return "error no cases chosen"; 
            }
		}
	}
}
