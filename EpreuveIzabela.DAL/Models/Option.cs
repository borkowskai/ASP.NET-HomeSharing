using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    public partial class Option :IEntity<int>
    {
        private int _idOption;
        private string _libelle;

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

        public int Id
        {
            get
            {
                return _idOption;
            }
        }
    }
}
