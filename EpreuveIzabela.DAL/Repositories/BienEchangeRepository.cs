using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    class BienEchangeEchangeRepository : BaseRepository<BienEchange, int>
    {

        public BienEchangeEchangeRepository(string Cnstr): base (Cnstr){
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM BienEchange WHERE idBien=@idBien;";
            SelectAllCommand = "SELECT * FROM BienEchange;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idBien equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  BienEchange (titre ,DescCourte ,DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal, Photo, AssuranceObligatoire, isEnabled, DisabledDate, Latitude, Longitude, idMembre, DateCreation )
                            OUTPUT inserted.idBien VALUES(@titre, @DescCourte, @DescLong, @NombrePerson, @Pays, @Ville, @Rue, @Numero, @CodePostal, @Photo, @AssuranceObligatoire, @isEnabled, @DisabledDate, @Latitude, @Longitude, @idMembre, @DateCreation ;";
            UpdateCommand = @"UPDATE  BienEchange
                           SET titre=@titre,DescCourte= @DescCourte, DescLong=@DescLong, NombrePerson=@NombrePerson, Pays=@Pays, Ville=@Ville, Rue=@Rue, Numero=@Numero, CodePostal=@CodePostal, Photo=@Photo, AssuranceObligatoire=@AssuranceObligatoire, isEnabled=@isEnabled, DisabledDate=@DisabledDate, Latitude=@Latitude, Longitude=@Longitude, idMembre=@idMembre, DateCreation=@DateCreation
                         WHERE idBien = @idBien;";
            DeleteCommand = @"DELETE FROM BienEchange  WHERE idBien = @idBien;";
        }




        public override IEnumerable<BienEchange> GetAll()
        {
            return base.getAll(Map);
        }
        // @id n'est pas necessaire comme chez Khun -- > cmd.Parameters.AddWithValue("@id", id)
        // cela est deja protege par la toolbox
        public override BienEchange GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idBien", id);
            return base.getOne(Map, QueryParameters);
        }
        // pas besoin d'instancier Disco parce que MapToDico retourne Dictionnary 
        // nous avons besoin d'id de C# pour garder OUTPUT inserted.idBien mais pour le momoent on ne l'utilise pas plus
        // 
        public override BienEchange Insert(BienEchange toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdBien = id;
            return toInsert;
        }


        public override bool Update(BienEchange toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@idBien", id);
            return base.Delete(QueryParameters);

        }

        //public IEnumerable<BienEchange> GetBienEchangesFromMembre(int id)
        //{
        //    //pas possible d'utiliser procedure stocker parce que je n'ai pas fait encore repos BienEchangeEcnage
        //    //SelectAllCommand = "Exec RecupBienEchangeMembre  @idMembre";
        //    SelectAllCommand = "select * from BienEchange where fk_Membre = @idMembre";
        //    Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
        //    QueryParameters.Add("idMembre", id);
        //    return base.getAll(Map, QueryParameters);
        //}

        #region Mappers
        private Dictionary<string, object> MapToDico(BienEchange toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idBien"] = toInsert.Id;
            p["titre"] = toInsert.Titre;
            p["DescCourte"] = toInsert.DescCourte;
            p["DescLong"] = toInsert.DescCourte;
            p["NombrePerson"] = toInsert.NombrePerson;
            p["Pays"] = toInsert.Pays;
            p["Ville"] = toInsert.Ville;
            p["Rue"] = toInsert.Rue;
            p["Numero"] = toInsert.Numero;
            p["CodePostal"] = toInsert.CodePostal;
            p["Photo"] = toInsert.Photo;
            p["AssuranceObligatoire"] = toInsert.AssuranceObligatoire;
            p["isEnabled"] = toInsert.IsEnabled;
            p["DisabledDate"] = toInsert.DisabledDate;
            p["Latitude"] = toInsert.Latitude;
            p["Longitude"] = toInsert.Longitude;
            p["idMembre"] = toInsert.IdMembre;
            p["dateCreation"] = toInsert.DateCreation;
            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme Titre qu'il ya dans la base de donnees 
        private BienEchange Map(SqlDataReader arg)
        {
            return new BienEchange()
            {
                IdBien = (int)arg["idBien"],
                Titre = arg["titre"].ToString(),
                DescCourte = arg["DescCourte"].ToString(),
                DescLong = arg["DescLong"].ToString(),
                NombrePerson = (int)arg["NombrePerson"],
                Pays = (int)arg["Pays"],
                Ville = arg["Ville"].ToString(),
                Rue = arg["Rue"].ToString(),
                Numero = arg["Numero"].ToString(),
                CodePostal = arg["CodePostal"].ToString(),
                Photo = arg["Photo"].ToString(),
                AssuranceObligatoire = (bool)arg["AssuranceObligatoire"],
                IsEnabled = (bool)arg["isEnabled"],
                DisabledDate = (DateTime)arg["DisabledDate"],
                Latitude = arg["Latitude"].ToString(),
                Longitude = arg["Longitude"].ToString(),
                IdMembre = (int)arg["idMembre"],
                DateCreation = (DateTime)arg["dateCreation"]     
            };
        }
        #endregion


    }
}
