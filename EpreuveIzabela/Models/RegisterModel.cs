using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Models
{
    public class RegisterModel
    {
        private string _nom;
        private string _prenom;
        private string _login;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private int _pays;
        private string _telephone;
        private string _photoUser;

        [Required(ErrorMessage = "this field is obligatory")]
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

        [Required(ErrorMessage = "this field is obligatory")]
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
        [Required(ErrorMessage = "this field is obligatory")]
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
        [Required(ErrorMessage = "this field is obligatory")]
        [DataType(DataType.EmailAddress)]
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
        [Required(ErrorMessage = "this field is obligatory")]
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
        [Required(ErrorMessage = "this field is obligatory")]
        [Compare("Password", ErrorMessage = "yours passwords are diffrent")] //You can localize your Error message 
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
            }
        }
        [Required(ErrorMessage = "this field is obligatory")]
        public int Pays
        {
            get
            {
                return _pays;
            }

            set
            {
                _pays = value;
            }
        }
        [Required(ErrorMessage = "this field is obligatory")]
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
                return _photoUser;
            }

            set
            {
                _photoUser = value;
            }
        }
    }
}