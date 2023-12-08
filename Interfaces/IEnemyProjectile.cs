namespace LegendofZelda.Interfaces
{
    public interface IEnemyProjectile : ISprite
    {
        void collide();
        public bool keepThrowing { get; set; }
    }
}
