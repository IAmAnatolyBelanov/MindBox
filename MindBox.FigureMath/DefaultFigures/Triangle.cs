namespace MindBox.DefaultFigures
{
    public class Triangle : ITriangle
    {
        public Triangle(IReadOnlyList<float> sides)
        {
            if (sides.Count != 3)
            {
                throw new ArgumentException($"Triangle must have 3 sides", nameof(sides));
            }
            if (!RightSides(sides))
            {
                throw new ArgumentException($"Can not create triangle with entered sides", nameof(sides));
            }

            float[] angles = CalculateAnglesByThreeSides(sides);

            Sides = sides;
            Angles = angles;
            Area = CalculateArea(sides[0], sides[1], angles[0]);
            IsRectangular = CalculateIsRectangular(sides);
        }

        public IReadOnlyCollection<float> Sides { get; }

        public IReadOnlyCollection<float> Angles { get; }

        public bool IsRectangular { get; }

        public float Area { get; }

        private static float[] CalculateAnglesByThreeSides(IReadOnlyList<float> sides)
        {
            var angles = new float[3];
            for (int i = 0; i < 3; i++)
            {
                var counterClockwiseSide = i - 1 < 0 ? sides[i - 1 + 3] : sides[i - 1];
                var clockwiseSide = sides[i];
                var oppositeSide = i - 2 < 0 ? sides[i - 2 + 3] : sides[i - 2];

                angles[i] = CalculateAngle(clockwiseSide, counterClockwiseSide, oppositeSide);
            }

            return angles;
        }

        private static float CalculateAngle(float clockwiseSide, float counterClockwiseSide, float oppositeSide)
        {
            return MathF.Acos((clockwiseSide * clockwiseSide + counterClockwiseSide * counterClockwiseSide - oppositeSide * oppositeSide)
                / (2 * clockwiseSide * counterClockwiseSide));
        }

        private static float CalculateArea(float counterClockwiseSide, float clockwiseSide, float angle)
        {
            var area = 0.5f * counterClockwiseSide * clockwiseSide * MathF.Sin(angle);
            return area;
        }

        private static bool CalculateIsRectangular(IReadOnlyList<float> sides)
        {
            for (int i = 0; i < 3; i++)
            {
                if (sides[i] * sides[i] == sides.Take(i).Sum(x => x * x) + sides.Skip(i + 1).Sum(x => x * x))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool RightSides(IReadOnlyList<float> sides)
        {
            for (int i = 0; i < 3; i++)
            {
                if (sides[i] > sides.Take(i).Sum() + sides.Skip(i + 1).Sum())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
