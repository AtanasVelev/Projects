using Library.Models;
using System.Collections.Generic;

namespace Library.Services
{
    public interface ICustomerServices
    {
        void AddCustomer(string name, long idCard, string address, Gender gender, int phoneNum, string email, long egn);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        void UpdateCustomer(int id, string name, long egn, long idCard, string address, Gender gender, int phoneNum, string email);
    }
}