using DAN_L_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_L_Dejan_Prodanovic.Service
{
    class ServiceClass:IService
    {
        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (AudioPlayerDataEntities context = new AudioPlayerDataEntities())
                {

                    tblUser newUser = new tblUser();

                    newUser.UserName = user.UserName;
                    newUser.UserPassword = user.UserPassword;
                   

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();

                    return newUser;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblUser GetUserByUserName(string username)
        {
            try
            {
                using (AudioPlayerDataEntities context = new AudioPlayerDataEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                          where x.UserName == username
                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblUser GetUserByUserNameAndPassword(string username,string password)
        {
            try
            {
                using (AudioPlayerDataEntities context = new AudioPlayerDataEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                    where x.UserName == username
                                    && x.UserPassword == password
                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblSong> GetSongs()
        {
            try
            {
                using (AudioPlayerDataEntities context = new AudioPlayerDataEntities())
                {
                    List<tblSong> list = new List<tblSong>();
                    list = (from x in context.tblSongs select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblSong AddSong(tblSong song)
        {
            try
            {
                using (AudioPlayerDataEntities context = new AudioPlayerDataEntities())
                {

                    tblSong newSong = new tblSong();

                    newSong.SongName = song.SongName;
                    newSong.Author = song.Author;
                    newSong.SongLength = song.SongLength;


                    context.tblSongs.Add(newSong);
                    context.SaveChanges();

                    return newSong;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


    }
}
