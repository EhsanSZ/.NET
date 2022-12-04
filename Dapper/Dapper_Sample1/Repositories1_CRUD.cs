using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Repositories
{

    public interface ICustomerRepository
    {
        int Add(CustomerDto customer);
        int Add(List<CustomerDto> customers);
        int Delete(long Id);
        int Delete(List<long> Ids);
        int Update(CustomerDto customer);
        int Update(List<CustomerDto> customers);
        List<CustomerDto> GetCustomers();
        CustomerDto Find(long Id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly string conectionString = @"Server=DESKTOP-62N3GQT\MSSQLSERVER2019;Initial Catalog=DapperDb; integrated security=true";


        public int Add(CustomerDto customer)
        {
            string Sql = "INSERT INTO Customers (Name , LastName) Values (@Name , @LastName) ";
            var conection = new SqlConnection(conectionString);

            var result = conection.Execute(Sql, new { Name = customer.Name, LastName = customer.LastName });

            return result;
        }


        public int Add(List<CustomerDto> customers)
        {
            string Sql = "INSERT INTO Customers (Name , LastName) Values (@Name , @LastName) ";
            var conection = new SqlConnection(conectionString);

            var result = conection.Execute(Sql, customers);

            return result;
        }

        public int Delete(long Id)
        {
            string Sql = "DELETE FROM Customers WHERE Id=@Id";
            var conection = new SqlConnection(conectionString);
            var result = conection.Execute(Sql, new { Id = Id });
            return result;
        }

        public int Delete(List<long> Ids)
        {
            string Sql = "DELETE FROM Customers WHERE Id=@Id";
            var conection = new SqlConnection(conectionString);
            var result = conection.Execute(Sql, Ids);
            return result;
        }

        public CustomerDto Find(long Id)
        {
            string Sql = "SELECT TOP 1 *  FROM Customers WHERE Id=@Id";
            var conection = new SqlConnection(conectionString);
            var customers = conection.Query<CustomerDto>(Sql, new { Id = Id }).FirstOrDefault();
            return customers;
        }

        public List<CustomerDto> GetCustomers()
        {
            string Sql = "SELECT *  FROM Customers";
            var conection = new SqlConnection(conectionString);
            var customers = conection.Query<CustomerDto>(Sql);
            return customers.ToList();

        }

        public int Update(CustomerDto customer)
        {
            string Sql = "UPDATE Customers SET Name=@Name , LastName=@LastName  WHERE Id=@Id";
            var conection = new SqlConnection(conectionString);
            var result = conection.Execute(Sql, new
            {
                Name = customer.Name,
                LastName = customer.LastName,
                Id = customer.Id
            });
            return result;



        }

        public int Update(List<CustomerDto> customers)
        {
            string Sql = "UPDATE Customers SET Name=@Name , LastName=@LastName  WHERE Id=@Id";
            var conection = new SqlConnection(conectionString);
            var result = conection.Execute(Sql, customers);
            return result;
        }
    }


    public class CustomerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
