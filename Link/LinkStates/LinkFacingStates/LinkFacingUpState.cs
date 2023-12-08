using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace States
{
    public class LinkFacingUpState : ILinkState
    {
        public LinkFacingUpState()
        {
        }
        public void Attack()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkAttackUpState();
        }
        public void MasterSwordAttack() 
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkAttackingUp(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkAttackUpState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateMasterSwordUp(Link.Instance.currentPosition);
            Link.Instance.currentProjectiles.Add(projectileSprite);
            Link.Instance.game.currentRoom.AddObject(projectileSprite);
            Debug.WriteLine(Link.Instance.currentProjectiles[0]);
        }
        public void ThrowProjectile()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkThrowingUpState();
            var projectileSprite = ProjectileSpriteFactory.Instance.CreateThrowableUp(Link.Instance.currentPosition, Link.Instance.throwable, Link.Instance);
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "top";
        }
    }
}

