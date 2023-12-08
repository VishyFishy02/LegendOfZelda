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
using System.Runtime.CompilerServices;
using LegendofZelda.Blocks;
using LegendofZelda.SpriteFactories;


namespace Collision
{
    public static class LinkProjectileBlockHandler
	{		

		public static void handleCollision(ILinkProjectile projectile, IBlock block, Room room, Game1 game)
		{
			if(block is PlainDarkBlueBlock)
			{
				// do nothing
			} else { 
				projectile.collide();
                if (!IsMasterSword(projectile))
                {
                    room.RemoveObject(projectile);
                }

                if (block is BombableDoorBlock && (projectile is BombDownSprite || projectile is BombLeftSprite | projectile is BombRightSprite || projectile is BombUpSprite )) 
				{ 
					room.RemoveObject(block);

					Graph currRoomGraph = game.roomsGraph;
					int currRoom = game.currentRoomIndex;
					// Need to remove the bombable wall on the other side
					List<int> roomsToEdit = new List<int>{currRoomGraph.GetUpRoom(currRoom), currRoomGraph.GetDownRoom(currRoom)};

					foreach(var roomToEdit in roomsToEdit) 
					{
						editRoom(roomToEdit, game);
					}
				}
			}
		}

        private static void editRoom(int roomToEdit, Game1 game)
        {
            List<ISprite> otherRoomSprites = game.rooms[roomToEdit].ReturnObjects();
            foreach (var sprite in otherRoomSprites)
            {
                if (sprite is BombableDoorBlock)
                {
					game.rooms[roomToEdit].RemoveObject(sprite);
                    break;
                }
            }
        }

        private static bool IsMasterSword(ILinkProjectile projectile)
        {
            return projectile is MasterSwordUpSprite || projectile is MasterSwordDownSprite
                || projectile is MasterSwordLeftSprite || projectile is MasterSwordRightSprite;
        }
    }
}
