using MindBox.DefaultFigures;

namespace Mindbox.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void CircleCreateSuccess()
        {
            var circle = new Circle(10);
        }

        [TestMethod]
        public void CircleAreaCorrect()
        {
            var expected = new Dictionary<float, float>
            {
                [10] = 314.1592653589793f,
                [500] = 785398.1633974483f,
                [0.05f] = 0.007853981633974483f
            };

            foreach (var data in expected)
            {
                var circle = new Circle(data.Key);
                Assert.AreEqual(data.Value, circle.Area);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CircleCreateError()
        {
            var circle = new Circle(-10);
        }
    }
}