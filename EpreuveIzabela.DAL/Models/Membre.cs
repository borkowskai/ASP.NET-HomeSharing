using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    //on mets la class en partien au cas ou on aura eu besoin d'ajouter une partie de fonctions
    public partial class Membre : IEntity<int>
    {

        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _email;
        private int _pays;
        private string _telephone;
        private string _login;
        private string _password;
        private string _photoUser;
        private bool _isDeleted;




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

        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }

            set
            {
                _isDeleted = value;
            }
        }

        //seulement get produit au moment du get
        // implementer plus tard apres les tests

        public string HashMDP
        {
            get
            {
                if (_password == null) throw new InvalidOperationException("Le mot de passe est vide");
                using (SHA512 sha512Hash = SHA512.Create())
                {

                    byte[] sourceBytes = Encoding.UTF8.GetBytes(_password);
                    byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                    return hash;
                }
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

        //preparer du terrain 
        //pour le moment juste get set parce que on ne l'utilise pas 
        public IEnumerable<Bien> Bien { get; set; }



        // si nous n'avons pas prepare du terrain pour les listes 
        // on laisse constructeru par default *on ne fait pas this.string

        public Membre()
        {
            this.Bien = new List<Bien>();


        }
    }
}
