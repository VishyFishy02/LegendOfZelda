using LegendofZelda;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace States
{
    public class LinkAttackLeftState : ILinkState
    {
        public LinkAttackLeftState()
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
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
                    Link.Instance.isDamaged);
        }
        public void NoInput() {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingLeft(Link.Instance.currentPosition,
                Link.Instance.isDamaged);
            Link.Instance.currentState = new LinkFacingLeftState();
        }
        public string Direction()
        {
            return "left";
        }
    }
}
