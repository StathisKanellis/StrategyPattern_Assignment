using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3a_Brief_Stathis_Kanellis
{
    class EShop
    {
        public static void EShopDemo()
        {
            var color = FactoryTShirt.ChoseColor();
            var size = FactoryTShirt.ChoseSize();
            var fabric = FactoryTShirt.ChoseFabric();

            TShirt shirt = new TShirt(color, size, fabric);
            FactoryCostTShirt.CostTShirt(shirt);

            CustomerPay.PayTShirt(shirt);

        }
    }

    class FactoryCostTShirt
    {
        public static TShirt CostTShirt(TShirt shirt)
        {
            ColorVariation colorVariation = new ColorVariation();
            colorVariation.Cost(shirt);
            SizeVariation sizeVariation = new SizeVariation();
            sizeVariation.Cost(shirt);
            FabricVariation fabricVariation = new FabricVariation();
            fabricVariation.Cost(shirt);
            return shirt;
        }
    }




    class FactoryTShirt
    {
        public static Color ChoseColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.Write("Chose TShirt color: 1) red, 2) orange, 3) yellow, 4) green, 5) blue, 6 )indigo, 7) violet: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int chose = int.Parse(Console.ReadLine().Trim());
            switch (chose)
            {
                case 1: return Color.blue;
                case 2: return Color.green;
                case 3: return Color.indigo;
                case 4: return Color.orange;
                case 5: return Color.red;
                case 6: return Color.violet;
                case 7: return Color.yellow;
                default: return Color.blue;

            }
        }

        public static Size ChoseSize()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.Write("Chose TShirt size: 1) XS, 2)  S, 3) M, 4)  L, 5)  XL, 6 ) XXL, 7)  XXXL: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int chose = int.Parse(Console.ReadLine().Trim());
            switch (chose)
            {
                case 1: return Size.XS;
                case 2: return Size.S;
                case 3: return Size.M;
                case 4: return Size.L;
                case 5: return Size.XL;
                case 6: return Size.XXL;
                case 7: return Size.XXXL;
                default: return Size.M;

            }
        }

        public static Fabric ChoseFabric()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("Chose TShirt fabric: 1) wool, 2) cotton, 3) polyester, 4) rayon, 5) linen, 6 ) cashmere, 7) silk: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int chose = int.Parse(Console.ReadLine().Trim());
            switch (chose)
            {
                case 1: return Fabric.wool;
                case 2: return Fabric.cotton;
                case 3: return Fabric.polyester;
                case 4: return Fabric.rayon;
                case 5: return Fabric.linen;
                case 6: return Fabric.cashmere;
                case 7: return Fabric.silk;
                default: return Fabric.cotton;

            }
        }
    }

    class ChoiceCustomer
    {
        private PaymentMethod _paymentMethod;
        private decimal _dueAmount;

        public void SelectPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void SetDueAmount(decimal amount)
        {
            _dueAmount = amount;
        }

        public bool Pay()
        {
            return _paymentMethod.Pay(_dueAmount);
        }
    }

    class CustomerPay
    {
        public static void PayTShirt(TShirt shirt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your tshirt cost: {shirt.Price}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("How would you like to pay? 1) Debit Cart , 2) Bank Transfer, 3) Cash: ");
            Console.ForegroundColor = ConsoleColor.White;

            var paytmentType = int.Parse(Console.ReadLine().Trim());
            var choice = new ChoiceCustomer();
            choice.SetDueAmount(shirt.Price);
            var simpleEshop = new SimpleEshop();
            var success = simpleEshop.PayOrder(paytmentType, choice);

            Console.WriteLine(success);
            Console.Read();

        }
    }


    class SimpleEshop
    {
        public bool PayOrder(int paymentMethod, ChoiceCustomer choice)
        {
            var payments = new Payments();

            bool success = payments.Pay(paymentMethod, choice);

            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Successful payment");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return success;
        }
    }

    class Payments
    {
        public bool Pay(int paytmentMethod, ChoiceCustomer choice)
        {
            switch (paytmentMethod)
            {
                case 1: choice.SelectPaymentMethod(new DebitCard()); break;
                case 2: choice.SelectPaymentMethod(new BankTransfer()); break;
                case 3: choice.SelectPaymentMethod(new Cash()); break;
                default: choice.SelectPaymentMethod(new Cash()); break;
            }

            var success = choice.Pay();
            return success;
        }
    }
}
