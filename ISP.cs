using System;

namespace InterfaceSegrigationPrinciple
{
    //A client should not be forced to use an interface if they are not using it. 
    public interface IEnquiry { double CalculateDiscount(); }

    public interface ICustomer : IEnquiry { void Add(); }

    public class Customer : ICustomer, IRead
    {
        public virtual double CalculateDiscount() { return 10; }
        public virtual void Add() { /*logic to add customer*/ }
        public virtual void Read() { /*logic to add customer*/ }

    }

    public interface IRead : ICustomer { void Read(); }

    public class Consumer
    {
        static void Main(string[] args)
        {

            ICustomer obj = new Customer();
            obj.Add();
            obj.CalculateDiscount();

            IRead objj = new Customer();
            objj.Add();
            objj.CalculateDiscount();
            objj.Read();
        }
    }
}
