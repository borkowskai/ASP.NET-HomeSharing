using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    //on mets la class en partien au cas ou on aura eu besoin d'ajouter une partie de fonctions
    public partial class Pays : IEntity<int> {

        private int _idPays;
        private string _libelle;
        private string _photo;

        public int IdPays
        {
            get
            {
                return _idPays;
            }

            set
            {
                _idPays = value;
            }
        }

        public string Libelle
        {
            get
            {
                return _libelle;
            }

            set
            {
                _libelle = value;
            }
        }

        public string Photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }

        public int Id
        {
            get
            {
                return _idPays;
            }
        }
    }
}
