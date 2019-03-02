using System;
namespace StudyPatterns
{
    #region Prototype Data
    public interface IPrototype
    {
        IPrototype Clone();
    }

    public class Block : IPrototype
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public string Color { get; set; }

        public IPrototype Clone()
        {
            Block clone = this.MemberwiseClone() as Block;
            clone.Color = this.Color;
            return clone;
        }

        public override string ToString()
        {
            return $"{this.Height}x{this.Width} {this.Color} block";
        }
    }
    #endregion

    #region Test
    public class PrototypeTest
    {
        public static void MainProgram()
        {
            var blockForCoping = new Block() { Width = 100, Height = 50, Color = "red" };
            var blockCopy = blockForCoping.Clone();

            Console.WriteLine($"{blockCopy} is copy of {blockForCoping}");
        }
    }
    #endregion

}