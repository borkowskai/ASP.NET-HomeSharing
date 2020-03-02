using EpreuveIzabela.Areas.Membre.Models;
using EpreuveIzabela.DAL.Models;
using EpreuveIzabela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Tools.Mappers
{
    // <summary>
    /// Use to define function for mapping models
    /// </summary>
    /// /// on peut le mettre dans les classes Models mais ici on regroupe tout
    /// au niveau de preformance c'est la meme chose
    /// 
    /// on fait en static pour que soit utilisable partout sans instancier 
    public static class MapToDBModel
    {
        public static Membre LoginToMember(LoginModel lm)
        {
            return new Membre()
            {
                Login = lm.Login,
                Password = lm.Password
            };
        }
        internal static ProfileModel MemberToProfile(Membre mmodel)
        {
            if (mmodel == null) return null;
            return new ProfileModel()
            {
                Id = mmodel.Id,
                Nom = mmodel.Nom,
                Prenom = mmodel.Prenom,
                Login = mmodel.Login,
                Email = mmodel.Email,
                //Pays = mmodel.Pays,
                Telephone =mmodel.Telephone
            };
        }

        public static Membre RegisterToMembre(RegisterModel rm)
        {
            return new Membre()
            {
                Nom = rm.Nom,
                Prenom = rm.Prenom,
                Login =rm.Login,
                Email = rm.Email,
                //il ne faut pas hasher , c'est le SQL server qui le fait pour nous
                Password = rm.Password,
                Pays = rm.Pays,
                Telephone =rm.Telephone,
                PhotoUser =rm.PhotoUser   
            };
        }

        public static BienModel BienToBienModel (Bien bm)
        {
            return new BienModel()
            {
                IdBien = bm.IdBien,
                Titre = bm.Titre,
                DescriptionCourte =bm.DescriptionCourte,
                DescriptionLongue = bm.DescriptionLongue,
                //Photo =bm.Photo,
                DateCreation = bm.DateCreation,
                DateSuppression=bm.DateSuppression,
                Capacité=bm.Capacité
            };
        }

        public static PaysModel PaysToPaysModel(Pays pm) 
        {
            return new PaysModel()
            {
                IdPays = pm.IdPays,
                Libelle = pm.Libelle
            };
        }



    }
}