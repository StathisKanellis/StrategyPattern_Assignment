using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3a_Brief_Stathis_Kanellis
{
    abstract class PaymentMethod
    {
        public abstract bool Pay(decimal amount);
    }

    class DebitCard : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            if (amount <= 0m || amount > 1000)
            {
                Console.WriteLine($"Paying {amount} using Credit declined");
                return false;
            }
            else
            {
                Console.WriteLine($"Paying {amount} using Credit Card");
                return true;
            }
        }
    }

    class BankTransfer : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            if (amount <= 0m || amount > 1000)
            {
                Console.WriteLine($"Paying {amount} using PayPal declined");
                return false;
            }
            else
            {
                Console.WriteLine($"Paying {amount} using PayPal");
                return true;
            }
        }
    }

    class Cash : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            if (amount <= 0m)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Cash {amount} it's ok");
                return true;
            }
        }
    }
}
