using System;
using Data.Utilities;

namespace DatabaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.CreateDatabaseSchema();
            Console.WriteLine("Schema Created");
            Console.ReadKey();
        }
    }
}
