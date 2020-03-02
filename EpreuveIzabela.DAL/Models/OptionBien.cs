using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    public partial class OptionBien : IEntity<int>
    {
        private int _idOption;
        private int idBien;
        private string _Valeur;

        public int IdOption
        {
            get
            {
                return _idOption;
            }

            set
            {
                _idOption = value;
            }
        }

        public int IdBien
        {
            get
            {
                return idBien;
            }

            set
            {
                idBien = value;
            }
        }

        public string Valeur
        {
            get
            {
                return _Valeur;
            }

            set
            {
                _Valeur = value;
            }
        }

        public int Id
        {
            get
            {
                //TODO double int
                throw new NotImplementedException();
            }
        }
    }

}