using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    public partial class Bien :IEntity<int>
    {
        private int _idBien;
        private string _titre;
        private string _descriptionCourte;
        private string _descriptionLongue;
        private string _photo;
        private DateTime _dateCreation;
        private DateTime _dateSuppression;
        private string _capacité;
        private int fk_Pays;
        private int fk_Membre;

        public int IdBien
        {
            get
            {
                return _idBien;
            }

            set
            {
                _idBien = value;
            }
        }

        public string Titre
        {
            get
            {
                return _titre;
            }

            set
            {
                _titre = value;
            }
        }

        public string DescriptionCourte
        {
            get
            {
                return _descriptionCourte;
            }

            set
            {
                _descriptionCourte = value;
            }
        }

        public string DescriptionLongue
        {
            get
            {
                return _descriptionLongue;
            }

            set
            {
                _descriptionLongue = value;
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

        public DateTime DateCreation
        {
            get
            {
                return _dateCreation;
            }

            set
            {
                _dateCreation = value;
            }
        }

        public DateTime DateSuppression
        {
            get
            {
                return _dateSuppression;
            }

            set
            {
                _dateSuppression = value;
            }
        }

        public string Capacité
        {
            get
            {
                return _capacité;
            }

            set
            {
                _capacité = value;
            }
        }

        public int Fk_Pays
        {
            get
            {
                return fk_Pays;
            }

            set
            {
                fk_Pays = value;
            }
        }

        public int Fk_Membre
        {
            get
            {
                return fk_Membre;
            }

            set
            {
                fk_Membre = value;
            }
        }

        public int Id
        {
            get
            {
                return _idBien;
            }
        }
    }
}
