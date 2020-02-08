using System;

namespace Library.Services
{
    public interface IBookCustomerServices
    {
        int GetAllBooksRentedForPeriod(int year, int month);
        void RentABook(int bookId, int customerId, DateTime dateFrom, DateTime dateTo);
    }
}