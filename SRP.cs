using System;

namespace SingleResponsibilityPrinciple
{
    //A class should take care of only one responsibility.
    public class Customer
    {
        public void Add()
        {
            try
            {
                // logic to add customer
            }
            catch (Exception ex)
            {
                //log the Exception
                System.IO.File.WriteAllText(@"C:Error.txt", ex.ToString()); 
                // Here Customer Class has a single responsibility to add customer

                //Logining invalid customer responsibility is delegated/transfered to Handle Error Class.
                HandleError obj = new HandleError();
                obj.LogError(ex.ToString());
            }
        }
    }

    public class HandleError
    {
        public void LogError(string error)
        {
            System.IO.File.WriteAllText(@"C:Error.txt", error);
        }
    }
}