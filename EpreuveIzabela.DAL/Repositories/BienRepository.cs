using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    class BienRepository : BaseRepository<Bien, int>
    {

        public BienRepository(string Cnstr): base (Cnstr){
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM Bien WHERE idBien=@idBien;";
            SelectAllCommand = "SELECT * FROM Bien;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idBien equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  Bien (Titre ,DescriptionCourte ,DescriptionLongue, Photo, DateCreation, DateSuppression, Capacité, Fk_Pays, Fk_Membre)
                            OUTPUT inserted.idBien VALUES(@Titre ,@DescriptionCourte ,@DescriptionLongue, @Photo, @DateCreation, @DateSuppression, @Capacité, @Fk_Pays, @Fk_Membre;";
            UpdateCommand = @"UPDATE  Bien
                           SET Titre=@Titre ,DescriptionCourte=@DescriptionCourte ,DescriptionLongue=@DescriptionLongue, Photo=@Photo, DateCreation=@DateCreation, DateSuppression=@DateSuppression,Capacité=@Capacité, Fk_Pays=@Fk_Pays, Fk_Membre=@Fk_Membre
                         WHERE IdBien = @IdBien;";
            DeleteCommand = @"DELETE FROM Bien  WHERE IdBien = @IdBien;";
        }




        public override IEnumerable<Bien> GetAll()
        {
            return base.getAll(Map);
        }
        // @id n'est pas necessaire comme chez Khun -- > cmd.Parameters.AddWithValue("@id", id)
        // cela est deja protege par la toolbox
        public override Bien GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idBien", id);
            return base.getOne(Map, QueryParameters);
        }
        // pas besoin d'instancier Disco parce que MapToDico retourne Dictionnary 
        // nous avons besoin d'id de C# pour garder OUTPUT inserted.idBien mais pour le momoent on ne l'utilise pas plus
        // 
        public override Bien Insert(Bien toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdBien = id;
            return toInsert;
        }


        public override bool Update(Bien toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdBien", id);
            return base.Delete(QueryParameters);

        }

        public IEnumerable<Bien> GetBiensFromMembre(int id)
        {
            //pas possible d'utiliser procedure stocker parce que je n'ai pas fait encore repos BienEcnage
            //SelectAllCommand = "Exec RecupBienMembre  @idMembre";
            SelectAllCommand = "select * from Bien where fk_Membre = @idMembre";
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idMembre", id);
            return base.getAll(Map, QueryParameters);
        }

        #region Mappers
        private Dictionary<string, object> MapToDico(Bien toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idBien"] = toInsert.Id;
            p["titre"] = toInsert.Titre;
            p["descriptionCourte"] = toInsert.DescriptionCourte;
            p["descriptionLongue"] = toInsert.DescriptionLongue;
            //p["Photo"] = toInsert.Photo;
            p["dateCreation"] = toInsert.DateCreation;
            p["dateSuppression"] = toInsert.DateSuppression;
            p["capacité"] = toInsert.Capacité;
            p["fk_Pays"] = toInsert.Fk_Pays;
            p["fk_Membre"] = toInsert.Fk_Membre;

            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme Titre qu'il ya dans la base de donnees 
        private Bien Map(SqlDataReader arg)
        {
            return new Bien()
            {
                IdBien = (int)arg["idBien"],
                Titre = arg["titre"].ToString(),
                DescriptionCourte = arg["descriptionCourte"].ToString(),
                DescriptionLongue = arg["descriptionLongue"].ToString(),
                //Photo = arg["photo"].ToString(),
                DateCreation = (DateTime)arg["dateCreation"],
                DateSuppression = (DateTime)arg["dateSuppression"],
                Capacité = arg["capacité"].ToString(),
                Fk_Pays = (int)arg["fk_Pays"],
                Fk_Membre = (int)arg["fk_Membre"]
            };
        }
        #endregion


    }
}
