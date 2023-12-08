using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkThrowingRightState : ILinkState
    {
        public LinkThrowingRightState()
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
       
        public void NoInput()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingRightState();
        }
        public void Redraw()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkThrowingRight(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public string Direction()
        {
            return "right";
        }
    }
}
