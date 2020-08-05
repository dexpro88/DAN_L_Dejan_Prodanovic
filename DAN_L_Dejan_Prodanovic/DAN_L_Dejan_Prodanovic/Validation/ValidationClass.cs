using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_L_Dejan_Prodanovic.Validation
{
    class ValidationClass
    {
        public static bool IsPasswordValid(string password)
        {
            

            if (password.Length<6)
            {
                return false;
            }
            int numnberOfUpper = password.ToCharArray().Where(c => c >= 'A' && c <= 'Z').Count();

            if (numnberOfUpper<2)
            {
                return false;
            }

            return true;
        }
    }
}
