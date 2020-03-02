using EpreuveIzabela.DAL.Infra;
using EpreuveIzabela.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Models
{
    public partial class OptionBien : IEntity<CompositeKey<int, int>>
    {
        private int _idOption;
        private int idBien;
        private string _valeur;

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
                return _valeur;
            }

            set
            {
                _valeur = value;
            }
        }

        //cette partie pour une classe intermediare est obligatoire
        // dans le struct int on ne peut pas mettre 2 valeurs 
        // nous avons besoin de 2 id  de 2 tab => il faut creer un struct de 2 elements = ici CompositeKey de Infra
        public CompositeKey<int, int> Id
        {
            get
            {
                return new CompositeKey<int, int>() { PK1 = IdBien, PK2 = IdOption };
            }
        }
    }

}