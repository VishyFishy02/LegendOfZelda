using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static LegendofZelda.Link;
using Sprites;
using LegendofZelda.Interfaces;
using LegendofZelda;
using System.Linq.Expressions;

namespace LegendofZelda.SpriteFactories
{
    public class ProjectileSpriteFactory : ISpriteFactory
    {
        private Texture2D spriteSheet;
        private readonly static ProjectileSpriteFactory instance = new();

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ProjectileSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("LinkandProjectileSprites");
        }

        public ISprite CreateThrowableUp(Vector2 linkPosition, Throwables throwable, Link link)
        {
            switch (throwable)
            {
                case Throwables.BlueBoomerang:
                    return new BlueBoomerangUpSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.Boomerang:
                    return new BoomerangUpSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.BlueArrow:
                    return new BlueArrowUpSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Arrow:
                    return new ArrowUpSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Bomb:
                    return new BombUpSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Fire:
                    return new FireUpSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                default:
                    return null;
            }

        }

        public ISprite CreateThrowableDown(Vector2 linkPosition, Throwables throwable, Link link)
        {
            switch (throwable)
            {
                case Throwables.BlueBoomerang:
                    return new BlueBoomerangDownSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.Boomerang:
                    return new BoomerangDownSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.BlueArrow:
                    return new BlueArrowDownSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Arrow:
                    return new ArrowDownSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Bomb:
                    return new BombDownSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Fire:
                    return new FireDownSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                default:
                    return null;
            }

        }

        public ISprite CreateThrowableRight(Vector2 linkPosition, Throwables throwable, Link link)
        {
            switch (throwable)
            {
                case Throwables.BlueBoomerang:
                    return new BlueBoomerangRightSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.Boomerang:
                    return new BoomerangRightSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.BlueArrow:
                    return new BlueArrowRightSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Arrow:
                    return new ArrowRightSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Bomb:
                    return new BombRightSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Fire:
                    return new FireRightSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                default:
                    return null;
            }
        }

        public ISprite CreateThrowableLeft(Vector2 linkPosition, Throwables throwable, Link link)
        {
            switch (throwable)
            {
                case Throwables.BlueBoomerang:
                    return new BlueBoomerangLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.Boomerang:
                    return new BoomerangLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y, link);

                case Throwables.BlueArrow:
                    return new BlueArrowLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Arrow:
                    return new ArrowLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Bomb:
                    return new BombLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y);

                case Throwables.Fire:
                    return new FireLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y);


                default:
                    return null;
            }
        }

        public ISprite CreateMasterSwordUp(Vector2 position)
        {
            return new MasterSwordUpSprite(spriteSheet, position.X, position.Y);
        }
        public ISprite CreateMasterSwordDown(Vector2 position)
        {
            return new MasterSwordDownSprite(spriteSheet, position.X, position.Y);
        }
        public ISprite CreateMasterSwordRight(Vector2 position)
        {
            return new MasterSwordRightSprite(spriteSheet, position.X, position.Y);
        }
        public ISprite CreateMasterSwordLeft(Vector2 position)
        {
            return new MasterSwordLeftSprite(spriteSheet, position.X, position.Y);
        }
        public ISprite CreateMasterSwordExplosion(Vector2 position)
        {
            return new MasterSwordExplosionSprite(spriteSheet, position.X, position.Y);
        }
    }
}
