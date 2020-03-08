using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Areas.Membre.Models
{
    public class OptionModel
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
    }
}