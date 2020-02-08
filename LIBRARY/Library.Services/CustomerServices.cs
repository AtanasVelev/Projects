using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly LibraryContext db;

        public CustomerServices()
        {
            this.db = new LibraryContext();
        }

        public void AddCustomer(string name, long idCard, string address, Gender gender, int phoneNum, string email, long egn)
        {
            var customer = new Customer()
            {
                Name = name,
                IDcard = idCard,
                Address = address,
                Gender = gender,
                PhoneNumber = phoneNum,
                Email = email,
                EGN = egn
            };
            db.Customers.Add(customer);
            db.SaveChanges();

        }
        public void UpdateCustomer(int id, string name, long egn, long idCard, string address, Gender gender, int phoneNum, string email)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("There is not a customer with this id");
            }
            customer.Name = name;
            customer.EGN = egn;
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
        public IEnumerable<Customer> GetAllCustomers()
        {
            return db.Customers;
        }
    }
}
