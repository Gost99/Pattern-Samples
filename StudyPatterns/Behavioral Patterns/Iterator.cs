using System;
using System.Collections.Generic;
namespace StudyPatterns
{
    #region Iterator Data
    public interface IAbstractIterator
    {
        QueueItem First();
        bool IsDone { get; }
        QueueItem Next();

        QueueItem Current { get; }
    }

    public interface IAbstractCollection
    {
        IAbstractIterator GetIterator();
    }

    public class QueueItem : Object
    {
        public QueueItem(int indx, string fulName, string usrName)
        {
            Position = indx;
            FullName = fulName;
            UserName = usrName;
        }
        public int Position { get; set; }

        public string FullName { get; private set; }

        public string UserName { get; private set; }
    }

    public class QueueCollection : IAbstractCollection
    {
        private List<QueueItem> _items = new List<QueueItem>();
        public IAbstractIterator GetIterator()
        {
            return new QueueIterator(this);
        }

        public int Count { get { return _items.Count; } }

        public QueueItem this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    public class QueueIterator : IAbstractIterator
    {
        private QueueCollection _queue;
        private int _step = 1;
        private int _current = 0;

        public QueueIterator(QueueCollection items)
        {
            this._queue = items;
        }

        public QueueItem Current
        {
            get { return _queue[_current] as QueueItem; }
        }

        public QueueItem First()
        {
            _current = 0;
            return _queue[_current] as QueueItem;
        }

        public bool IsDone
        {
            get { return _current >= _queue.Count; }
        }

        public QueueItem Next()
        {
            _current += _step;
            if (!IsDone)
                return _queue[_current] as QueueItem;
            else

                return null;
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
    }
    #endregion

    #region Test
    public class IteratorTest
    {
        public static void MainProgram()
        {
            var collection = new QueueCollection();
            collection[0] = new QueueItem(1, "Me", "@gost");
            collection[1] = new QueueItem(2, "Vlad", "@symon");
            collection[2] = new QueueItem(3, "Tolyan", "@tolik");
            collection[3] = new QueueItem(4, "Semenov", "@kek");

            QueueIterator iterator = (QueueIterator)collection.GetIterator();

            iterator.Step = 1;

            for (var item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine($"{item.Position}.{item.FullName}({item.UserName})");
            }
        }
    }
    #endregion
}