using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    public partial class Avis :IEntity<int>
    {
        private int _idAvis;
        private DateTime _dateAvis;
        //TODO check if double float
        private float _scoreAvis;
        private string _descriptionAvis;
        private int fk_Membre;
        private int fk_Bien;

        public int IdAvis
        {
            get
            {
                return _idAvis;
            }

            set
            {
                _idAvis = value;
            }
        }

        public DateTime DateAvis
        {
            get
            {
                return _dateAvis;
            }

            set
            {
                _dateAvis = value;
            }
        }

        public float ScoreAvis
        {
            get
            {
                return _scoreAvis;
            }

            set
            {
                _scoreAvis = value;
            }
        }

        public string DescriptionAvis
        {
            get
            {
                return _descriptionAvis;
            }

            set
            {
                _descriptionAvis = value;
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

        public int Fk_Bien
        {
            get
            {
                return fk_Bien;
            }

            set
            {
                fk_Bien = value;
            }
        }

        public int Id
        {
            get
            {
                return _idAvis;

            }
        }
    }
}
