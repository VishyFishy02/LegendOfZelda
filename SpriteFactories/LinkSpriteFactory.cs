using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Sprites;
using LegendofZelda.Interfaces;

namespace LegendofZelda.SpriteFactories
{
    public class LinkSpriteFactory : ISpriteFactory
    {
        private Texture2D spriteSheet;
        private Texture2D dyingSpriteSheet;
        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private LinkSpriteFactory()
        {
        }

        public void Initialize(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }

        public ISprite CreateLinkDying(Vector2 linkPosition)
        {
            return new LinkDyingSprite(spriteSheet, linkPosition.X, linkPosition.Y, dyingSpriteSheet);

        }

        public ISprite CreateLinkWinning(Vector2 linkPosition)
        {
            return new LinkWinningSprite(spriteSheet, linkPosition.X, linkPosition.Y);

        }

        public ISprite CreateLinkFacingUp(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkFacingUpSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);

        }
        public ISprite CreateLinkFacingDown(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkFacingDownSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }

        public ISprite CreateLinkFacingRight(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkFacingRightSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }

        public ISprite CreateLinkFacingLeft(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkFacingLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }

        //Walking sprites

        public ISprite CreateLinkWalkingUp(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkWalkingUpSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }


        public ISprite CreateLinkWalkingDown(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkWalkingDownSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }

        public ISprite CreateLinkWalkingLeft(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkWalkingLeftSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }


        public ISprite CreateLinkWalkingRight(Vector2 linkPosition, bool isDamaged)
        {
            return new LinkWalkingRightSprite(spriteSheet, linkPosition.X, linkPosition.Y, isDamaged);
        }



        //--------------------THROWING METHODS---------------------//
        public ISprite CreateLinkThrowingUp(Vector2 position, bool isDamaged)
        {
            return new LinkThrowingUpSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkThrowingRight(Vector2 position, bool isDamaged)
        {
            return new LinkThrowingRightSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkThrowingLeft(Vector2 position, bool isDamaged)
        {
            return new LinkThrowingLeftSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkThrowingDown(Vector2 position, bool isDamaged)
        {
            return new LinkThrowingDownSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        //-------------------------END THROWING METHODS------------------------//

        //--------------------Attacking METHODS---------------------//
        public ISprite CreateLinkAttackingUp(Vector2 position, bool isDamaged)
        {
            return new LinkAttackUpSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkAttackingRight(Vector2 position, bool isDamaged)
        {
            return new LinkAttackRightSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkAttackingLeft(Vector2 position, bool isDamaged)
        {
            return new LinkAttackLeftSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        public ISprite CreateLinkAttackingDown(Vector2 position, bool isDamaged)
        {
            return new LinkAttackDownSprite(spriteSheet, position.X, position.Y, isDamaged);
        }

        //-------------------------END Attacking METHODS------------------------//

        //--------------------Idle Walking METHODS---------------------//
        public ISprite CreateLinkIdleWalkingSprite(Vector2 position, bool isDamaged, string side)
        {
            switch (side)
            {
                case "top":
                    return new LinkIdleWalkingUpSprite(spriteSheet, position.X, position.Y, isDamaged);
                    
                case "bottom":
                    return new LinkIdleWalkingDownSprite(spriteSheet, position.X, position.Y, isDamaged);
                    
                case "left":
                    return new LinkIdleWalkingLeftSprite(spriteSheet, position.X, position.Y, isDamaged);
                    
                case "right":
                    return new LinkIdleWalkingRightSprite(spriteSheet, position.X, position.Y, isDamaged);
                   
                default:
                    return new LinkIdleWalkingRightSprite(spriteSheet, position.X, position.Y, isDamaged);
                    
            }
            
        }


        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("LinkandProjectileSprites");
            dyingSpriteSheet = content.Load<Texture2D>("enemy_death");
        }
    }
}