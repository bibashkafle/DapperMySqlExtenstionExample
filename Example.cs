using System;
using DapperMySqlExtenstion;
namespace DapperMySqlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Database("Connectionstring");

            //Example 1
            database.Read<Customer>("select * from customers");

            //Example 2
            database.Read<Customer>("select * from customers where address = @address",new { address = "Chicago"});

            //For Transaction
            //database.BeginTransaction();
            //database.CommitTransaction();

            var input = new Customer
            {
                FirstName = "Bibash",
                LastName = "Kafle",
                Address = "Chicago"
            };
            database.Write("insert into customers(firstName, middleName, lastName) values(@firstName, @middleName, @lastName)", input);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
