using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationHttpHeaders
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            if (x >= 9999)
            {
                return x + y - 1;
            }
            
            return x + y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0) throw new Exception("Dzielenie przez Zero");
            return x / y;
        }
    }

}
