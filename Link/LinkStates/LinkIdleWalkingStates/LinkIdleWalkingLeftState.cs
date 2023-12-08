using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkIdleWalkingLeftState : ILinkState
    {
        public LinkIdleWalkingLeftState()
        { 
        }

        //Invalid states from the current state
        public void Attack() { }
        public void MasterSwordAttack() { }
        public void ThrowProjectile() { }
        public void MoveLeft() { }
        
        public void MoveUp()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingUpState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }
        public void MoveDown()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingDownState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDown(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }
        public void MoveRight()
        {
            Link.Instance.UpdatePosition();
            Link.Instance.currentState = new LinkWalkingRightState();
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingRight(Link.Instance.currentPosition, Link.Instance.isDamaged);
        }
        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
            Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingLeftState();
        }
        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "left";
        }
    }
}
