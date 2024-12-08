namespace AquariumProject.Model.Utils
{
    public static class UserUtils
    {
        private static Random s_random = new Random();

        public static float NextSingle(float minValue = 0, float maxValue = 1)
        {
            return s_random.NextSingle() * (maxValue - minValue) + minValue;
        }
    }
}
