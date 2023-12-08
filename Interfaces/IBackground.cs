namespace LegendofZelda.Interfaces
{
    public interface IBackground : ISprite
    {
        public void SetTransitionDirection(string direction);
        public bool IsTransitioning { get; }
    }
}
