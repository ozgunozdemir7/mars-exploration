using System;

namespace Mars.Exploration
{
    public static class IntegerExtensions
    {
        public static int ToInt(this string input)
        {
            if (!int.TryParse(input, out int output))
            {
                throw new ArgumentException($"invalid integer value:{input}");
            }

            return output;
        }
    }
}
