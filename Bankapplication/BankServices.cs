using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Bankapplication
{
    public class BankServices : IBankServices
    {
        #region Functions
        public void GetBankAccountByName()
        {
            Console.WriteLine("Type in the name of the bank account");
            string username = Console.ReadLine().ToLower();
            var user = DbContext.GetUserByName(username);

            if (user == null && username != "")
            {
                user = CreateBankAccount(username);
            }

            if (username == "" || username == null)
            {
                Console.WriteLine(BankTotalBalance());
            }
            Transaction(user);
        }

        private string BankTotalBalance()
        {
            int totalBalance = DbContext.BankTotalBalance();
            return $"The total balance of all the bank accounts combined is {totalBalance}";
        }

        private void Transaction(BankAccount user)
        {
            while(true)
            {
                Console.WriteLine("Type in the amount you would like to widhraw or deposit.");
                var money = Console.ReadLine();
                if(isTransactionable(money))
                {
                    TransactionType(Convert.ToInt32(money), user);
                    UpdateBalance(user);
                    Console.WriteLine($"Your current balance is {DbContext.GetUserBalance(user)}");
                    GetBankAccountByName();
                }
                break;
            }
        }

        private void UpdateBalance(BankAccount user)
        {
            var filter = Builders<BankAccount>.Filter.Eq("_id", user.Id);
            var update = Builders<BankAccount>.Update.Set("Balance", user.Balance).Set("Transaction", new BsonArray(user.Transaction)).Set("Increment", user.Increment+1);
            DbContext.account.UpdateOne(filter, update);
        }


        private void TransactionType(int money, BankAccount user)
        {
            if (money < 0)
            {
                user.Transaction.Add($"Withdrew -{money}");
            }
            else if (money >= 1)
            {
                user.Transaction.Add($"Deposit +{money}");
            }
            else
            {
                Console.WriteLine("No deposit or withdrawal has been made");
            }
            user.Balance += money;
        }

        private bool isTransactionable(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Your request was invalid. Transactions have to be integers with no decimals nor letters.\n");
                return false;
            }
        }

        public BankAccount CreateBankAccount(string name)
        {
            var account = new BankAccount(name, 0, new List<string>(), 0 );
            DbContext.account.InsertOne(account);
            return account;
        }

        #endregion
    }
}
