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

        public static bool IsSongLengthValid(string songLength)
        {
            if (songLength.Length!=5)
            {
                return false;
            }
            if (!Char.IsDigit(songLength[0])|| !Char.IsDigit(songLength[1])||
                !Char.IsDigit(songLength[3])|| !Char.IsDigit(songLength[4]))
            {
                return false;
            }
            if (songLength[2]!=':')
            {
                return false;
            }
            string minutes = songLength.Substring(0,2);
            string seconds = songLength.Substring(3,5);

            int min = Int32.Parse(minutes);
            int sec = Int32.Parse(seconds);

            if (min>59||sec>59)
            {
                return true;
            }
            return false;
        }
    }
}
