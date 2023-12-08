namespace LegendofZelda.Interfaces
{
    public interface IGohma : IEnemy
    {
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public bool IsDamaged { get; set; }
    }
}
