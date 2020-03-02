using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Models
{
    public class PaysModel
    {
        private int _idPays;
        private string _libelle;

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
    }
}