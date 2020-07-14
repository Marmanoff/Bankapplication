using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Bankapplication
{
    public class DbContext
    {
        public static MongoClient client = new MongoClient(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        public static IMongoDatabase db = client.GetDatabase(ConfigurationManager.AppSettings.Get("BankDB"));
        public static IMongoCollection<BankAccount> account = db.GetCollection<BankAccount>("BankAccount");

        public static BankAccount GetUserByName(string username)
        {
            BankAccount user = DbContext.account.AsQueryable().Where(x => x.FullName == username).FirstOrDefault();
            return user;
        }

        public static int BankTotalBalance()
        {
            return DbContext.account.Aggregate().ToList<BankAccount>().Sum(x => x.Balance);
        }

        public static bool isSameIncrement(BankAccount user)
        {
            var dbCurrent = DbContext.account.AsQueryable().Where(x => x.FullName == user.FullName).Select(x => x.Increment).FirstOrDefault();
            if(user.Increment == dbCurrent)
            {
                return true;
            }
            return false;
        }

        public static int GetUserBalance(BankAccount user)
        {
            if (!DbContext.isSameIncrement(user))
            {
                user.Balance = DbContext.account.AsQueryable().Where(x => x.Id == user.Id).Select(x => x.Balance).FirstOrDefault();
            }
            return user.Balance;

        }

    }
}
