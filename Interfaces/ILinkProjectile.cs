namespace LegendofZelda.Interfaces
{
    public interface ILinkProjectile : ISprite
    {
        void collide();
        public bool IsDone { get; }
    }
}
