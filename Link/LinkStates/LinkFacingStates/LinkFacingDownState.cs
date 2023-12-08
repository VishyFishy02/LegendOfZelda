using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace States
{
    public class LinkFacingDownState : ILinkState
    {
        public LinkFacingDownState()
        {
        }
        public void Attack()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingDown(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkAttackDownState();
        }
        public void MasterSwordAttack() 
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingDown(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkAttackDownState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateMasterSwordDown(Link.Instance.currentPosition);
            Link.Instance.currentProjectiles.Add(projectileSprite);
            Link.Instance.game.currentRoom.AddObject(projectileSprite);
            Debug.WriteLine(Link.Instance.currentProjectiles);
        }
        public void ThrowProjectile()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkThrowingDownState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableDown(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
            Link.Instance.currentProjectiles.Add(projectileSprite);
            Link.Instance.game.currentRoom.AddObject(projectileSprite);
        }
        public void MoveUp()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingUpState();
        }
        public void MoveDown()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingDownState();
        }
        public void MoveLeft()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingLeftState();
        }
        public void MoveRight()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkWalkingRightState();
        }
        public void NoInput()
        {
            // Don't need to do anything when already in facing state
        }
        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "bottom";
        }
    }
}

