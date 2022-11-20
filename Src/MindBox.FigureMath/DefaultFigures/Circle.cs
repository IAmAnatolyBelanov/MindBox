namespace MindBox.DefaultFigures
{
    public class Circle : ICircle
    {
        public Circle(float radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), $"{nameof(radius)} must be greater then 0");
            }

            Radius = radius;
            Area = MathF.PI * radius * radius;
        }

        public float Radius { get; set; }

        public float Area { get; private set; }
    }
}
