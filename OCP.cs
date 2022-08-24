using System;

namespace OpenClosePrinciple
{
    //Extension should be preffered over modification
    //A class should be closed for modification but open for extension.

    public class Customer
    {
        public int _CustType
        {
            get { return _CustType; }
            set { _CustType = value; }
        }
        public virtual double CalculateDiscount() { return 5; }
        public void Add() { /*logic to add customer*/ }

        // Here, the problem is as the CustType increase, we have to modify the original Customer class everytime.
        //To avoid it, we will extend the Customer Class and override the method by creating a class for each custtype
        public virtual double CalculateDiscountBasedOnType()
        {
            if (_CustType == 1)
                return 5;
            else
                return 10;
        }
    }

    public class GoldCustomer : Customer
    {
        public override double CalculateDiscount() { return base.CalculateDiscount() + 50; }
    }

    public class SilverCustomer : Customer
    {
        public override double CalculateDiscount() { return base.CalculateDiscount() + 30; }
    }
}

