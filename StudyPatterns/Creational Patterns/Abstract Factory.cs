namespace StudyPatterns
{
    #region Abstract Factory Data
    public interface IAbstractFactory
    {
        ILaptop CreateLaptop();
        IComputer CreateComputer();
        IPhone CreatePhone();
    }

    public class MicrosoftFactory : IAbstractFactory
    {
        public IComputer CreateComputer()
        {
            return new MicrosoftComputer();
        }

        public ILaptop CreateLaptop()
        {
            return new MicrosoftLaptop();
        }

        public IPhone CreatePhone()
        {
            return new MicrosoftPhone();
        }
    }

    public class AppleFactory : IAbstractFactory
    {
        public IComputer CreateComputer()
        {
            return new AppleComputer();
        }

        public ILaptop CreateLaptop()
        {
            return new AppleLaptop();
        }

        public IPhone CreatePhone()
        {
            return new ApplePhone();
        }
    }

    public class AsusFactory : IAbstractFactory
    {
        public IComputer CreateComputer()
        {
            return new AsusComputer();
        }

        public ILaptop CreateLaptop()
        {
            return new AsusLaptop();
        }

        public IPhone CreatePhone()
        {
            return new AsusPhone();
        }
    }

    public interface ILaptop
    {

    }

    public interface IComputer
    {

    }

    public interface IPhone
    {

    }

    public class AppleLaptop : ILaptop
    {

    }

    public class MicrosoftLaptop : ILaptop
    {

    }

    public class AsusLaptop : ILaptop
    {

    }

    public class AppleComputer : IComputer
    {

    }

    public class MicrosoftComputer : IComputer
    {

    }

    public class AsusComputer : IComputer
    {

    }

    public class ApplePhone : IPhone
    {

    }

    public class MicrosoftPhone : IPhone
    {

    }

    public class AsusPhone : IPhone
    {

    }

    #endregion

    #region Test
    public class AbstractFactoryTest
    {
        private static IAbstractFactory factory;
        public static void MainProgram()
        {
            factory = new AppleFactory();
            var c1 = factory.CreateComputer();
            var l1 = factory.CreateLaptop();
            var p1 = factory.CreatePhone();

            System.Console.WriteLine($"You have bought {c1.GetType().Name}, {l1.GetType().Name} " +
                $"and {p1.GetType().Name}");

        }
    }

    #endregion

}