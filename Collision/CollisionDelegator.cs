using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using LegendofZelda;
using LegendofZelda;

namespace Collision
{
    public class CollisionDelegator
	{   
        private Room room;
        private Game1 game;
        public CollisionDelegator(Room room, Game1 game) {
            this.room = room;
            this.game = game;
        }
        
        // method which will assign the object pair to it's pairwise handler
        public void handleCollision(ISprite obj, ISprite otherObj)
		{
            string side = determineSide(obj, otherObj);
            firstObjEnemyProj(obj, otherObj, side);
            firstObjLinkProj(obj, otherObj, side);
            firstObjEnemy(obj, otherObj, side);
            firstObjLink(obj, otherObj, side);
            firstObjBlock(obj, otherObj, side);
            firstObjItem(obj, otherObj, side);                                                                    
		}
        private string determineSide(ISprite obj, ISprite otherObj)
        {
            Rectangle objectRec = obj.DestinationRectangle;
            Rectangle otherRec = otherObj.DestinationRectangle;
            // first determine if top-bottom or left-right collision
            string type;
            Rectangle intersectionArea = Rectangle.Intersect(objectRec, otherRec);
            if (intersectionArea.Height < intersectionArea.Width)
            {
                type = "top-bottom";
            }
            else
            {
                type = "left-right";
            }
            // then get obj's position in relation to otherObj to return side
            if (type == "top-bottom")
            {
                if (objectRec.Location.Y < otherRec.Location.Y)
                {
                    return "bottom";
                }
                else
                {
                    return "top";
                }
            }
            else
            {
                if (objectRec.Location.X < otherRec.Location.X)
                {
                    return "right";
                }
                else
                {
                    return "left";
                }
            }
        }
        private void collisionRectangle(ref ISprite obj, ref ISprite otherObj, ref Rectangle collisionRect)
        {
            Rectangle rectangle1 = obj.DestinationRectangle;
            Rectangle rectangle2 = otherObj.DestinationRectangle;
            Rectangle.Intersect(ref rectangle1, ref rectangle2, out collisionRect);
        }
        private void firstObjEnemyProj(ISprite obj, ISprite otherObj, string side)
        {
                if (obj is IEnemyProjectile) {
                IEnemyProjectile projectile = obj as IEnemyProjectile;
                if (otherObj is IBlock) // enemyProj - block
                {
                    EnemyProjectileBlockHandler.handleCollision(projectile, this.room);
                }
                if (otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // enemyProj - Link
                {
                    side = determineSide(otherObj, obj);
                    EnemyProjectileLinkHandler.handleCollision(projectile,side, this.room);
                }
            } 
        }
        private void firstObjLinkProj(ISprite obj, ISprite otherObj, string side)
        {
            if (obj is ILinkProjectile)
            {
                ILinkProjectile linkProjectile = obj as ILinkProjectile;
                if(otherObj is IBlock)// linkProj - Block
                {
                    IBlock block = otherObj as IBlock;
                    LinkProjectileBlockHandler.handleCollision(linkProjectile, block, this.room, this.game);
                }else if (otherObj is IEnemy) // linkProj-enemy
                {
                    IEnemy enemy = otherObj as IEnemy;                    
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side, this.room);
                }
            }
        }
        private void firstObjEnemy(ISprite obj, ISprite otherObj, string side)
        {
            if (obj is IEnemy)
            {
                IEnemy enemy = obj as IEnemy;
                if(otherObj is IBlock) // enemy-block
                {
                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new Rectangle();
                    collisionRectangle(ref obj,  ref otherObj, ref collisionRect);
                    EnemyBlockHandler.handleCollision(enemy, block, side);
                }
                else if (otherObj is ILinkProjectile) // LinkProj - enemy
                {
                    ILinkProjectile linkProjectile = otherObj as ILinkProjectile;
                    LinkProjectileEnemyHandler.handleCollision(linkProjectile, enemy, side, this.room);
                }
                else if (otherObj is INonAttackingSprite || otherObj is IAttackingSprite) // Link-enemy # 2
                {
                    side = determineSide(otherObj, obj);
                    LinkEnemyHandler.handleCollision(enemy, side, this.game);
                }
            }
        }
        private void firstObjLink(ISprite obj, ISprite otherObj, string side)
        {
            if(obj is INonAttackingSprite || obj is IAttackingSprite) // obj is Link's sprite
            {   
                if(otherObj is IEnemy)// link enemy # 1
                {
                    IEnemy enemy = otherObj as IEnemy;
                    LinkEnemyHandler.handleCollision(enemy, side, this.game);

                } 
                else if (otherObj is IBlock && obj is INonAttackingSprite) // link block, link is not attacking
                {
                    IBlock block = otherObj as IBlock;
                    Rectangle collisionRect = new();
                    collisionRectangle(ref obj, ref otherObj, ref collisionRect);
                    LinkBlockHandler.handleCollision(block, this.room, side, collisionRect);
                } 
                else if(otherObj is IEnemyProjectile) // enemy projectile - link
                {
                    IEnemyProjectile enemyProj = otherObj as IEnemyProjectile;
                    EnemyProjectileLinkHandler.handleCollision(enemyProj,side, this.room);
                } 
                else if(otherObj is IItem)
                {
                    IItem item = otherObj as IItem;
                    LinkItemHandler.handleCollision(item, this.room);
                }
            }
        }
        private void firstObjBlock(ISprite obj, ISprite otherObj, string side)
        {
             if (obj is IBlock)
             {
                side = determineSide(otherObj, obj);
                IBlock block = obj as IBlock;
                if(otherObj is INonAttackingSprite) // otherObj is Link that is not attacking: Link- block
                {
                        Rectangle collisionRect = new Rectangle();
                        collisionRectangle (ref obj, ref Link.Instance.currentLinkSprite, ref collisionRect);
                        LinkBlockHandler.handleCollision(block, this.room, side, collisionRect);                                                           
                } else if (otherObj is IEnemyProjectile) // Enemy-Proj - block
                {
                    IEnemyProjectile projectile = otherObj as IEnemyProjectile;
                    EnemyProjectileBlockHandler.handleCollision(projectile, this.room);
                } else if (otherObj is ILinkProjectile) // LinkProj - block
                {
                    ILinkProjectile projectile = otherObj as ILinkProjectile;
                    LinkProjectileBlockHandler.handleCollision(projectile, (IBlock)obj, room, game);
                } else if (otherObj is IEnemy) // Enemy - Block
                {
                    IEnemy enemy = otherObj as IEnemy;
                    Rectangle collisionRect = new Rectangle();
                    collisionRectangle( ref obj,  ref otherObj, ref collisionRect);
                    EnemyBlockHandler.handleCollision(enemy, block, side);
                }
             } 
        }
        private void firstObjItem(ISprite obj, ISprite otherObj, string side)
        {
             if (obj is IItem) 
             {
                IItem item = obj as IItem;
                if(otherObj is IAttackingSprite || otherObj is INonAttackingSprite) // Link - Item
                {
                    LinkItemHandler.handleCollision(item, this.room);
                }
             }
        }
    }
}