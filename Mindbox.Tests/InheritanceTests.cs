using MindBox;
using MindBox.DefaultFigures;

namespace Mindbox.Tests
{
    [TestClass]
    public class InheritanceTests
    {
        private static readonly Random random = new Random();

        [TestMethod]
        public void CreateFiguresSuccess()
        {
            var figures = new IFigure[]
            {
                new Circle(20),
                new Triangle(new float[] { 10, 10, 10 }),
                new CustomFigure(),
                new CustomPolygon(2, 8)
            };

            foreach (var figure in figures)
            {
                Assert.AreNotEqual(0, figure.Area);
            }
        }

        public class CustomFigure : IFigure
        {
            public float Area => random.Next(1, 100500);
        }

        public class CustomPolygon : IPolygon
        {
            public CustomPolygon(int a, int b)
            {
                Sides = (new float[a]).Select(x => random.Next(500, 1000) + x).ToArray();
                Angles = (new float[b]).Select(x => random.Next(1, 10) + x).ToArray();
                Area = Sides.Sum() - Angles.Sum();
            }

            public IReadOnlyCollection<float> Sides { get; }

            public IReadOnlyCollection<float> Angles { get; }

            public float Area { get; }
        }
    }
}
