using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankapplication
{
    public class BankAccount
    {
        [BsonId]
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Balance { get; set; }

        [BsonElement("transaction")]
        public List<string> Transaction { get; set; }

        public int Increment { get; set; }

        public BankAccount(string fullName, int balance, List<string> transaction, int increment)
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            FullName = fullName;
            Balance = balance;
            Transaction = transaction;
            Increment = increment;
        }
    }
}
