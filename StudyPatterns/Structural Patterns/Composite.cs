using System;
using System.Collections.Generic;
namespace StudyPatterns
{
    #region Composite Data
    public abstract class Component
    {
        protected int _size;

        public abstract void Add(Component c);
        public abstract void Remove(Component c);

        public abstract int GetSize();
    }

    public class File : Component
    {
        public File(int size)
        {
            _size = size;
        }

        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override int GetSize()
        {
            return _size;
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }
    }

    public class Directory : Component
    {
        private ICollection<Component> dir = new List<Component>();

        public override void Add(Component c)
        {
            dir.Add(c);
        }

        public override int GetSize()
        {
            int res = 0;
            foreach (var c in dir)
            {
                res += c.GetSize();
            }

            return res;
        }

        public override void Remove(Component c)
        {
            dir.Remove(c);
        }
    }
    #endregion

    #region Test
    public class CompositeTest
    {
        public static void MainProgram()
        {
            var f1 = new File(5);
            var f2 = new File(8);
            var d1 = new Directory();
            d1.Add(f1); d1.Add(f2);

            var f3 = new File(10);
            var d2 = new Directory();
            d2.Add(f3);

            d1.Add(d2);

            Console.WriteLine($"dir 1 size: {d1.GetSize()}");
            Console.WriteLine($"dir 2 size: {d2.GetSize()}");
            
        }
    }
    #endregion
}