using SFML.System;

namespace unum.Engine
{
    public static class MathHelper
    {
        public static float Lerp(float from, float to, float by)
        {
            return from * (1 - by) + to * by;
        }

        public static Vector2f Lerp(Vector2f from, Vector2f to, float by)
        {
            var retX = Lerp(from.X, to.X, by);
            var retY = Lerp(from.Y, to.Y, by);
            return new Vector2f(retX, retY);
        }

        public static class Easing
        {
            public static float EaseOutCubic(float start, float end, float value)
            {
                value--;
                end -= start;
                return end * (value * value * value + 1) + start;
            }

            public static Vector2f EaseOutCubic(Vector2f from, Vector2f to, float currentTime)
            {
                var retX = EaseOutCubic(from.X, to.X, currentTime);
                var retY = EaseOutCubic(from.Y, to.Y, currentTime);
                return new Vector2f(retX, retY);
            }
        }
    }
}
