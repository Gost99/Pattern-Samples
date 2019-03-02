using System;
using System.Collections.Generic;
namespace StudyPatterns
{
    #region Command Data
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    public class BuyCommand : ICommand
    {
        private Store _store;

        private int _purchaseId;

        public int Price { get; private set; }

        public BuyCommand(Store store, int purchId, int price)
        {
            _store = store;
            Price = price;
            _purchaseId = purchId;
        }

        public void Execute()
        {
            _store.NewOrder(_purchaseId, Price);
        }

        public void UnExecute()
        {
            _store.CancelOrder(_purchaseId, Price);
        }
    }

    public class Store
    {
        public void NewOrder(int purchaseId, int price)
        {
            Console.WriteLine($"Purchase №{purchaseId}({price}) was executed.");
        }

        public void CancelOrder(int purchaseId, int price)
        {
            Console.WriteLine($"Purchase №{purchaseId} canceled successfully. {price} returned to your wallet");
        }
    }

    public class Customer
    {
        private List<BuyCommand> _purchases = new List<BuyCommand>();

        public Customer(int startMoney)
        {
            Wallet = startMoney;
        }

        public Customer SetCommand(ICommand command)
        {
            _purchases.Add(command as BuyCommand);
            return this;
        }

        public int Wallet { get; private set; }

        public void BuySmth()
        {
            foreach (var cmd in _purchases)
            {
                cmd.Execute();
                Wallet -= cmd.Price;
            }
           
        }

        public void CancelPurchases(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if(i < _purchases.Count)
                {
                    _purchases[_purchases.Count - 1 - i].UnExecute();
                    Wallet += _purchases[_purchases.Count - 1 - i].Price;
                }
            }
        }



    }
    #endregion

    #region Test
    public class CommandTest
    {
        public static void MainProgram()
        {
            var store = new Store();
            var purch1 = new BuyCommand(store, 1, 600);
            var purch2 = new BuyCommand(store, 2, 900);
            var purch3 = new BuyCommand(store, 3, 1000);
            var me = new Customer(3000);

            me.SetCommand(purch1).SetCommand(purch2).SetCommand(purch3);

            me.BuySmth();
            Console.WriteLine($"My Wallet: {me.Wallet}");

            me.CancelPurchases(3);
            Console.WriteLine($"My Wallet: {me.Wallet}");
        }
    }
    #endregion
}