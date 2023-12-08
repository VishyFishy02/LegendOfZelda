namespace Interfaces
{
    public interface ILinkState
    {
        void Attack();
        void MasterSwordAttack();
        void ThrowProjectile();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Redraw();
        void NoInput();
        string Direction();
    }
}
