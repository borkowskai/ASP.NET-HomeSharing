using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Models
{
    public class MembreModel
    {
        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _email;
        private string _telephone;
        private string _login;
        private string _password;
        private string _photoUser;




        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
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

        public string PhotoUser
        {
            get
            {
                return _photoUser;
            }

            set
            {
                _photoUser = value;
            }
        }

        
       

        //implementer IEntity => avoir id de C# - plus facile la manipulation
        public int Id
        {
            get
            {
                return _idMembre;
            }
        }

    }
}