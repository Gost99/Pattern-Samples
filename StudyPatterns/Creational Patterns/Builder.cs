using System;
namespace StudyPatterns
{
    #region Builder Data
    public interface IComputerBuilder
    {
        void AddMotherBoard();
        void AddRAM();
        void AddCPU();
        void AddVideoCard();
        void AddSSD();
        Computer GetResult();
    }

    public class AppleComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();
        public void AddCPU()
        {
            _computer.CPU = "Core i7";
        }

        public void AddMotherBoard()
        {
            _computer.MotherBoard = "Asus";
        }

        public void AddRAM()
        {
            _computer.RAM = "8 GB";
        }

        public void AddSSD()
        {
            _computer.SSD = "128 GB";
        }

        public void AddVideoCard()
        {
            _computer.VideoCard = "GTX 1080";
        }

        public Computer GetResult()
        {
            return _computer;
        }
    }

    public class Director
    {
        private IComputerBuilder _builder;

        public Director(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer CreatePowerfullComputer()
        {
            _builder.AddMotherBoard();
            _builder.AddCPU();
            _builder.AddRAM();
            _builder.AddSSD();
            _builder.AddVideoCard();
            return _builder.GetResult();
        }
    }

    public class Computer
    {
        public string MotherBoard { get; set; }

        public string  CPU { get; set; }

        public string  RAM { get; set; }

        public string  VideoCard { get; set; }

        public string  SSD { get; set; }
    }
    #endregion

    #region Test
    public class BuilderTest
    {
        public static void MainProgram()
        {
            var newBuilder = new AppleComputerBuilder();
            var director = new Director(newBuilder);
            var createdComputer = director.CreatePowerfullComputer();

            Console.WriteLine($"Hi! We created computer with next configuration: " +
                $"{createdComputer.MotherBoard} mb, {createdComputer.CPU} processor, " +
                $"{createdComputer.RAM} ram, {createdComputer.SSD} ssd memory, " +
                $"{createdComputer.VideoCard} video card");
        }
    }
    #endregion
}