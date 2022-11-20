namespace MindBox.DefaultFigures
{
    public interface IPolygon : IFigure
    {
        public IReadOnlyCollection<float> Sides { get; }

        public IReadOnlyCollection<float> Angles { get; }
    }
}
