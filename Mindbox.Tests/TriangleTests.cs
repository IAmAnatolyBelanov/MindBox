using MindBox.DefaultFigures;

namespace Mindbox.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TriangleCreateSuccess()
        {
            var triangle = new Triangle(new float[] { 3, 4, 5 });
        }

        [TestMethod]
        public void TriangleAreaCorrect()
        {
            var expected = new Dictionary<float[], float>
            {
                [new float[] { 3, 4, 5 }] = 4.8f,
                [new float[] { 10, 15, 20 }] = 54.46383f,
                [new float[] { 0.02f, 0.04f, 0.05f }] = 0.000303973648f
            };

            foreach (var data in expected)
            {
                var circle = new Triangle(data.Key);
                Assert.AreEqual(data.Value, circle.Area);
            }
        }

        [TestMethod]
        public void TriangleIsRectangularCorrect()
        {
            var expected = new Dictionary<float[], bool>
            {
                [new float[] { 3, 4, 5 }] = true,
                [new float[] { 10, 15, 20 }] = false,
                [new float[] { 0.4f, 0.3f, 0.5f }] = true
            };

            foreach (var data in expected)
            {
                var circle = new Triangle(data.Key);
                Assert.AreEqual(data.Value, circle.IsRectangular);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleCreateError()
        {
            var triangle = new Triangle(new float[] { 100, 1, 1 });
        }
    }
}
