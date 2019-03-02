using System;
using System.Collections.Generic;
namespace StudyPatterns
{
    #region CoR Data
    public interface IHandler
    {
        IHandler SetHandler(IHandler handler);

        object Handle(object request);

    }

    public abstract class HumanHandler : IHandler
    {
        private IHandler _next;

        public IHandler SetHandler(IHandler next)
        {
            _next = next;
            return _next; 
        }

        public virtual object Handle(object request)
        {
            if (this._next != null)
                return this._next.Handle(request);
            else
                return null;
        }

    }

    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class KidHandler : HumanHandler
    {
        public override object Handle(object request)
        {
            if ((request as Human).Age <= 12)
                return $"{((Human)request).Name} is a kid";
            else
                return base.Handle(request);
        }
    }

    public class TeenHandler : HumanHandler
    {
        public override object Handle(object request)
        {
            if ((request as Human).Age <= 18)
                return $"{((Human)request).Name} is a teen";
            else return base.Handle(request);
            
        }
    }

    public class AdultHandler : HumanHandler
    {
        public override object Handle(object request)
        {
            if ((request as Human).Age <= 60)
                return $"{((Human)request).Name} is a adult";
            else return base.Handle(request);

        }
    }

    public class OldHandler : HumanHandler
    {
        public override object Handle(object request)
        {
            return $"{((Human)request).Name} is a old";
        }
    }
    #endregion

    #region Test
    public class CoRTest
    {
        public static void MainProgram()
        {
            var handler = new KidHandler();
            handler.SetHandler(new TeenHandler()).SetHandler(new AdultHandler()).SetHandler(new OldHandler());

            var humanList = new List<Human>
            {
                new Human(){Name="Misha", Age=19},
                new Human(){Name="Ded", Age=70},
                new Human(){Name="Mark", Age=16}
            };

            foreach (var h in humanList)
            {
                Console.WriteLine(handler.Handle(h));
            }
        }
    }
    #endregion



}