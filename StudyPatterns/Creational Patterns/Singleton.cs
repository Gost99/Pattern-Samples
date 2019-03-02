using System;
namespace StudyPatterns
{
    #region Singleton Data
    public class Sun 
    {
        private static Sun _instance;

        private Sun() {  }

        private static object locker = new object();

        public static Sun GetInstance()
        {
            if(_instance == null)
            {
                lock (locker)
                {
                    _instance = new Sun();
                }
            }
            return _instance;
        }


    }

    //eager implementation
    public class Moon
    {
        private static readonly Moon _instance = new Moon();

        public int Size { get; private set; }

        private Moon()
        {
            Size = 128589125;
        }

        public static Moon GetInstance()
        {
            return _instance;
        }


    }

    #endregion

    #region Test
    public class SingletonTest
    {
        public static void MainProgram()
        {
            var sun = Sun.GetInstance();
            var newSun = Sun.GetInstance();

            if (sun == newSun)
                Console.WriteLine("Shit, we have two similar suns!");

            var moon = Moon.GetInstance();
            var newMoon = Moon.GetInstance();

            if (moon == newMoon)
                Console.WriteLine("Shit, we have two similar moons! Their radius is {0}", Moon.GetInstance().Size);

        }
    }
    #endregion
}