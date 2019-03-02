using System;
namespace StudyPatterns
{
    #region Adapter Data
    public interface ISoup
    {
        void Eat();
    }

    public class Soup : ISoup
    {
        public void Eat()
        {
            Console.WriteLine($"{this.GetType().Name} eating...");
        }
    }

    public interface IDrink
    {
        void Drink();
    }

    public class Beer : IDrink
    {
        public void Drink()
        {
            Console.WriteLine($"{this.GetType().Name} drinking...");
        }
    }


    public class DrinkSoupAdapter : IDrink
    {
        private Soup _soup = new Soup();

        public void Drink()
        {
            _soup.Eat();
        }
    }
    #endregion

    #region Test
    public class AdapterTest
    {
        public static void MainProgram()
        {
            IDrink soup = new DrinkSoupAdapter();
            soup.Drink();
        }
    }
    #endregion
}