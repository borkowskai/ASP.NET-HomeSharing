using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Areas.Membre.Models
{
    public class ProfileModel
    {
        //si le model du programmme (ici LoginModel) serait plein 
        //on pourrait utiliser directement Loginrmodel
        private int _id;
        private string _nom;
        private string _prenom;
        private string _login;
        private string _email;
        private string _password;
        private string _telephone;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }



        public string Telephone
        {
            get
            {
                return _telephone;
            }

            set
            {
                _telephone = value;
            }
        }

        public string PhotoUser
        {
            get
            {
                return GetPhoto();
            }

        }

        public int Pays
        {
            get
            {
                return GetPays();
            }

        }
        /// <summary>
        /// Function to generate the path to the profile picture
        /// </summary>
        /// <returns></returns>
        private string GetPhoto()
        {
            //TODO change the photo path
            //We can't use server.MapPath outside a Controller but we can use System.Web.Hosting.HostingEnvironment
            string folderpath = System.Web.Hosting.HostingEnvironment.MapPath("~/Photos/");
            string[] PicturesFiles = Directory.GetFiles(folderpath, Id + ".*");

            if (PicturesFiles.Count() > 0)
            {
                FileInfo i = new FileInfo(PicturesFiles[0]);


                return "/Photos/" + i.Name;
            }
            else
            {
                return "";
            }
        }

        //TODO GetPays()
        private int GetPays() 
        {
            return 0;
        }
    }
}