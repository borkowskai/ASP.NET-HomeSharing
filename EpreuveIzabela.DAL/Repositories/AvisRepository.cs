using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public partial class AvisRepository :BaseRepository<Avis, int>
    {
        public AvisRepository(string Cnstr) : base(Cnstr)
        {
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM Avis WHERE idAvis=@idAvis;";
            SelectAllCommand = "SELECT * FROM Avis;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idAvis equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  Avis (dateAvis, scoreAvis ,DescriptionAvis, fk_Membre, fk_Bien)
                            OUTPUT inserted.idAvis VALUES(@dateAvis, @scoreAvis ,@DescriptionAvis, @fk_Membre, @fk_Bien;";
            UpdateCommand = @"UPDATE  Avis
                           SET dateAvis=@dateAvis, scoreAvis=@scoreAvis ,DescriptionAvis=@DescriptionAvis, fk_Membre=@fk_Membre, fk_Bien=@fk_Bien
                         WHERE idAvis = @idAvis;";
            DeleteCommand = @"DELETE FROM Avis  WHERE idAvis = @idAvis;";
        }




        public override IEnumerable<Avis> GetAll()
        {
            return base.getAll(Map);
        }
        // @id n'est pas necessaire comme chez Khun -- > cmd.Parameters.AddWithValue("@id", id)
        // cela est deja protege par la toolbox
        public override Avis GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idAvis", id);
            return base.getOne(Map, QueryParameters);
        }
        // pas besoin d'instancier Disco parce que MapToDico retourne Dictionnary 
        // nous avons besoin d'id de C# pour garder OUTPUT inserted.idAvis mais pour le momoent on ne l'utilise pas plus
        // 
        public override Avis Insert(Avis toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdAvis = id;
            return toInsert;
        }


        public override bool Update(Avis toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@idAvis", id);
            return base.Delete(QueryParameters);

        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Avis toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idAvis"] = toInsert.Id;
            p["dateAvis"] = toInsert.DateAvis;
            p["scoreAvis"] = toInsert.ScoreAvis;
            p["DescriptionAvis"] = toInsert.DescriptionAvis;
            p["fk_Membre"] = toInsert.Fk_Membre;
            p["fk_Bien"] = toInsert.Fk_Bien;

            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme Titre qu'il ya dans la base de donnees 
        private Avis Map(SqlDataReader arg)
        {
            return new Avis()
            {
                IdAvis = (int)arg["idAvis"],
                DateAvis = (DateTime)arg["dateAvis"],
                ScoreAvis =(float) arg["scoreAvis"],
                DescriptionAvis = arg["DescriptionAvis"].ToString(),
                Fk_Membre = (int)arg["fk_Membre"],
                Fk_Bien = (int)arg["fk_Bien"],
            };
        }
        #endregion

    }
}
