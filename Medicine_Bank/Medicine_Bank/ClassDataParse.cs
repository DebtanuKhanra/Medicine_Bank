using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_Bank
{
    internal class ClassDataParse
    {
        static string medicine_name, qty, price;
        public static string name
        {
            get
            {
                return medicine_name;
            }
            set
            {
                medicine_name = value;
            }
        }
        public static string quantity
        {
            get
            {
                return qty;

            }
            set
            {
                qty = value;
            }
        }

        public static string rupees
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}
