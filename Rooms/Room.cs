using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprites;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Blocks;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace LegendofZelda
{
    public class Room
    {
        private List<ISprite> sprites;
        private ISprite background;
        private List<ISprite> doors;
        private bool alreadyChecked, isBoshRushRoom, removePuzzleDoor, hasEntered;
        private readonly ISprite topBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock");
        private readonly ISprite bottomBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock");
        private readonly ISprite leftBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock");
        private readonly ISprite rightBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalBoundingBlock");
        public ISprite Background { get => background; set => background = value; }
        public bool isFinished { get; set; }
        public bool externallyChecked { get; set; }
        public Room(List<ISprite> sprites, ISprite background, bool isBoshRushRoom)
        {
            this.sprites = sprites;
            this.background = background;
            doors = new();
            isFinished = false;
            externallyChecked = false;
            alreadyChecked = false;
            removePuzzleDoor = false;
            this.isBoshRushRoom = isBoshRushRoom;
            if (isBoshRushRoom)
                RushRoomIncomplete();
            hasEntered = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            
            var ibackground = background as IBackground;
            if (!ibackground.IsTransitioning)
            {
                foreach (var sprite in sprites)
                {
                    //If the object is link , then don't draw it, will cause duplicates otherwise
                    if (!(sprite is IAttackingSprite) && !(sprite is INonAttackingSprite))
                    {
                        sprite.Draw(spriteBatch);
                    }
                    
                }
            }
        }

        public void Update()
        {
            if (isBoshRushRoom)
            {
                if (CheckIfFinished() && !alreadyChecked)
                {
                    alreadyChecked = true;
                    RushRoomComplete();
                }
            }

            background.Update();
            if (!((IBackground)background).IsTransitioning)
            {
                foreach (var sprite in sprites.ToList())
                {
                    sprite.Update();
                    if (sprite is IEnemy)
                    {
                        DealWithEnemies((IEnemy)sprite);
                    }
                    else if (sprite is ILinkProjectile)
                    {
                        DealWithLinkProjectiles((ILinkProjectile)sprite);
                    } else if (sprite is DepthPushableBlock)
                    {
                        if (((DepthPushableBlock)sprite).isPushed)
                        {
                            removePuzzleDoor = true;
                        }
                    }
                    if (sprite is PuzzleDoorBlock && removePuzzleDoor)
                    {
                        sprites.Remove(sprite);
                    }
                }
            }
        }

        // Only called in EnemiesPaused state
        public void ClockUpdate()
        {
            background.Update();
            if (!((IBackground)background).IsTransitioning)
            {
                foreach (var sprite in sprites.ToList())
                {
                    if (sprite is IEnemy) {
                    }
                    else
                    {
                        if (sprite is ILinkProjectile)
                        {
                            DealWithLinkProjectiles((ILinkProjectile)sprite);
                        }
                    }
                }
            }
        }
        
        //rush rooms methods//
        private void RushRoomIncomplete()
        {    
            sprites.Add(topBoundBlock);
            sprites.Add(bottomBoundBlock);
            sprites.Add(rightBoundBlock);
            sprites.Add(leftBoundBlock);
            foreach (var sprite in sprites.ToList())
            {
                if (sprite is OpenDoorBlock || sprite is OpenWhiteDoorBlock)
                {
                    doors.Add(sprite);
                    sprites.Remove(sprite);
                }
            }
        }
        private void RushRoomComplete()
        {
            sprites.Remove(topBoundBlock);
            sprites.Remove(bottomBoundBlock);
            sprites.Remove(rightBoundBlock);
            sprites.Remove(leftBoundBlock);
            sprites.AddRange(doors);
        }

        private bool CheckIfFinished()
        {
            foreach (var sprite in sprites.ToList())
            {
                if (sprite is IEnemy && !(sprite is TrapSprite))
                {
                    return false;
                }
            }
            isFinished = true;
            return true;
        }
        //end of rush rooms methods//

        private void DealWithLinkProjectiles(ILinkProjectile projectile)
        {
            if (projectile.IsDone)
                sprites.Remove(projectile);
        }

        private void DealWithEnemies(IEnemy enemy)
        {
            List<ISprite> enemyProjectiles = new();
            if (enemy is OldManBoss)
                enemyProjectiles = ((OldManBoss)enemy).getEnemyProjectiles();
            else if (enemy is GoriyaSprite)
                enemyProjectiles.Add(((GoriyaSprite)enemy).GetCurrentBoomerang());
            else if (enemy is DragonBossSprite)
                enemyProjectiles = ((DragonBossSprite)enemy).getEnemyProjectiles();
            foreach (IEnemyProjectile projectile in enemyProjectiles.ToList())
            {
                if (projectile != null)
                {
                    if (projectile.keepThrowing)
                    {
                        if (!sprites.Contains(projectile))
                            sprites.Add(projectile);
                    }
                    else
                    {
                        sprites.Remove(projectile);
                    }
                }
            }

            if (enemy.DyingComplete)
            {
                sprites.Remove(enemy);
                ISprite item = enemy.DropItem();
                if (item != null)
                {
                    SoundFactory.Instance.CreateSoundEffect("ItemDrop").Play();
                    sprites.Add(item);
                }
            }
        }
        public List<ISprite> ReturnObjects()
        {
            List<ISprite> copyOfSprites = new List<ISprite>(sprites);
            return copyOfSprites;
        }


        public void RemoveObject(ISprite sprite){sprites.Remove(sprite);}
        public void AddObject(ISprite sprite){sprites.Add(sprite);}

    }
}
