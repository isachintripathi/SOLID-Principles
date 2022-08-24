using System;

namespace DependecyInversionPrinciple
{
    //High level modules should not depends on low level modules
    //But should depends on abstraction
    public class Customer : ICustomer, IEnquiry
    {
        private IErrorHandler _err;
        public Customer(IErrorHandler error)
        {
            error = _err;
        }

        public void Add()
        {
            try
            {
                //logic to add customer
            }
            catch (System.Exception e)
            {
                // System.IO.File.WriteAllText(@"C:Error.txt", e.ToString());
                _err.LogError(e.ToString());
            }
        }
        public double CalculateDiscount() { _err.LogError("No Discounts for Enquiry persons"); return 0; }
        public static void Main(string[] args)
        {
            ICustomer cust = new Customer(new FileError());
            cust.CalculateDiscount();
            cust.Add();

            IEnquiry enq = new Customer(new DataError());
            enq.CalculateDiscount();
        }

    }

    public interface IEnquiry { double CalculateDiscount(); }

    public interface ICustomer : IEnquiry { void Add(); }

    public interface IErrorHandler { void LogError(string error); }

    public class FileError : IErrorHandler
    {
        public void LogError(string error)
        {
            System.IO.File.WriteAllText(@"C:Error.txt", error);
        }
    }

    public class DataError : IErrorHandler
    {
        public void LogError(string error)
        {
            System.IO.File.WriteAllText(@"C:Error.txt", error);
        }
    }

}

