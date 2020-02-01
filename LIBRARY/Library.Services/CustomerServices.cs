using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class CustomerServices
    {
        private readonly LibraryContext db;

        public CustomerServices()
        {
            this.db = new LibraryContext();
        }
        public void GetBooks(Book[] books)
        {

        }

        public void AddCustomer(string name, long idCard, string address, Gender gender, int phoneNum, string email)
        {
            var customer = new Customer()
            {
                Name = name,
                IDcard = idCard,
                Address = address,
                Gender = gender,
                PhoneNumber = phoneNum,
                Email = email
            };
            db.Customers.Add(customer);
            db.SaveChanges();

        }
        public void UpdateCustomer(int id, string name, int idCard, string address, Gender gender, int phoneNum, string email)
        {
            Customer customer = db.Customers.Find(id);
            // check if customer exists
            customer.Name = name;
            customer.IDcard = idCard;
            customer.Address = address;
            customer.Gender = gender;
            customer.PhoneNumber = phoneNum;
            customer.Email = email;
            db.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        public IQueryable<Customer> GetAllCustomers()
        {
            return db.Customers;
        }
    }
}
