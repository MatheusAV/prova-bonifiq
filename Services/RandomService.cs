namespace ProvaPub.Services
{
    public class RandomService
    {
        private Random random;

        public RandomService()
        {
            random = new Random();
        }

        public int GetRandom()
        {
            return random.Next(100);
        }
    }
}
