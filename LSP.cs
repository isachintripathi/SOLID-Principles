using System;
using System.Collections.Generic;

namespace LiskovSubstitutionPrinciple
{
    //parent class object can refer child class objects seamlessly during runtime polymorphism
    public class Customer
    {
        void Add() { /* logic to add a customer */ }
        public virtual double CalculateDiscount() { return 5; }

        public static void Main(string[] arg)
        {
            List<Customer> cust = new List<Customer>();
            cust.Add(new GoldCustomer());
            cust.Add(new SilverCustomer());
            cust.Add(new EnquiryCustomer());

            foreach (Customer c in cust) { c.Add(); }
        }
    }

    public class GoldCustomer : Customer
    {
        public override double CalculateDiscount()
        {
            return base.CalculateDiscount() + 50;
        }
    }

    public class SilverCustomer : Customer
    {
        public override double CalculateDiscount()
        {
            return base.CalculateDiscount() + 30;
        }
    }

    public class EnquiryCustomer : Customer
    {
        public override double CalculateDiscount()
        {
            return base.CalculateDiscount();
        }
    }
}