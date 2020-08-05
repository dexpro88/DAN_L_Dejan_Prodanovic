using DAN_L_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_L_Dejan_Prodanovic.Service
{
    interface IService
    {
        List<tblSong> GetSongs();
        tblUser AddUser(tblUser user);
        tblSong AddSong(tblSong user);

        tblUser GetUserByUserName(string username);
        tblUser GetUserByUserNameAndPassword(string username,string password);
    }
}
