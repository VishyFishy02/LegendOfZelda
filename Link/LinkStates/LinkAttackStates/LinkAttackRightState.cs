using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkAttackRightState : ILinkState
    {
        public LinkAttackRightState()
        {   
        }

        //Invalid states from the current state
        public void Attack() { }
        public void MasterSwordAttack() { }
        public void ThrowProjectile() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public void NoInput() 
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition, 
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingRightState();
        }
        public string Direction()
        {
            return "right";
        }
    }
}
