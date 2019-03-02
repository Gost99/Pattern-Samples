using System;
using System.Collections.Generic;
namespace StudyPatterns
{
    #region Flyweight Data
    public class Car
    {
        public int Weight { get; private set; }

        public string Model { get; private set; }

        public CarType Type { get; private set; }

        public Car(string model, int weight, CarType type)
        {
            Model = model;
            Weight = weight;
            Type = type;
        }
    }

    public class CarType
    {
        public int NumberOfDoor { get; set; }

        public int SeatingRows { get; set; }

        public bool IsOffRoading { get; set; }

        
    }

    public class CarTypeFactory
    {
        private static IDictionary<string, CarType> types = new Dictionary<string, CarType>();

        static  CarTypeFactory()
        {
            types.Add("Hatchback", new CarType() { NumberOfDoor = 4, SeatingRows = 2, IsOffRoading = false });
            types.Add("MPV", new CarType() { NumberOfDoor = 4, SeatingRows = 3, IsOffRoading = false });
            types.Add("Crossover", new CarType() { NumberOfDoor = 4, SeatingRows = 2, IsOffRoading = true });
        }

        public static CarType GetCarType(string key)
        {
            return types.ContainsKey(key) ? types[key] : null;
        }


    }
    #endregion

    #region Test
    public class FlyweightTest
    {
        public static void MainProgram()
        {
            var car1 = new Car("BMW x5", 1050, CarTypeFactory.GetCarType("MPV"));
            var car2 = new Car("Mersedes", 800, CarTypeFactory.GetCarType("bmw"));

            Console.WriteLine($"{car1.Model} - {car1.Type.NumberOfDoor} doors, {car1.Type.SeatingRows} seatingg rows");
            Console.WriteLine($"{car2.Model} - {car2.Type.NumberOfDoor} doors, {car2.Type.SeatingRows} seatingg rows");
        }
    }
    #endregion
}