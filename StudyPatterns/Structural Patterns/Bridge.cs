using System;
namespace StudyPatterns
{
    #region Bridge Data
    public interface IGun
    {
        void StartFire();
    }

    public class Rifle : IGun
    {
        public void StartFire()
        {
            Console.WriteLine("Tatatatatatatatatat!");
        }
    }

    public class Pistolet : IGun
    {
        public void StartFire()
        {
            Console.WriteLine("Piu   Piu   Piu!");
        }
    }

    public abstract class Soldier
    {
        protected IGun gun;
        public IGun Gun {
            set {
                gun = value;
                Console.WriteLine($"{this.GetType().Name} takes {gun.GetType().Name}");
            }
        }

        public Soldier(IGun gun)
        {
            Gun = gun;
        }

        public virtual void Attack()
        {
            gun.StartFire();
        }
    }

    public class Stormtrooper : Soldier
    {
        public Stormtrooper(IGun gun) : base(gun) { }
        
    }

    public class Bazookatrooper: Soldier
    {
        public Bazookatrooper(IGun gun) : base(gun) { }

        public override void Attack()
        {
            Console.WriteLine("Throw granade...");
            base.Attack();
        }

    }
    #endregion

    #region Test
    public class BridgeTest
    {
        public static void MainProgram()
        {
            var vasya = new Stormtrooper(new Pistolet());
            vasya.Attack();
            vasya.Gun = new Rifle();
            vasya.Attack();

            var dima = new Bazookatrooper(new Rifle());
            dima.Attack();
        }
    }
    #endregion
}