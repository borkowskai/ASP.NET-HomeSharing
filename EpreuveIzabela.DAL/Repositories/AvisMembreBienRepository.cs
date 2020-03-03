using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public partial class AvisMembreBienRepository : BaseRepository<AvisMembreBien, int>
    {
        public AvisMembreBienRepository(string Cnstr) : base(Cnstr)
        {
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM AvisMembreBien WHERE idAvis=@idAvis;";
            SelectAllCommand = "SELECT * FROM AvisMembreBien;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idAvis equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  AvisMembreBien (note, message, idMembre, idBien, DateAvis, Approuve)
                            OUTPUT inserted.idAvis VALUES(@note, @message, @idMembre, @idBien, @DateAvis, @Approuve;";
            UpdateCommand = @"UPDATE  AvisMembreBien
                           SET note=@note, message=@message, idMembre=@idMembre, idBien=@idBien, DateAvis=@DateAvis, Approuve=@Approuve
                         WHERE idAvis = @idAvis;";
            DeleteCommand = @"DELETE FROM AvisMembreBien  WHERE idAvis = @idAvis;";
        }




        public override IEnumerable<AvisMembreBien> GetAll()
        {
            return base.getAll(Map);
        }
        // @id n'est pas necessaire comme chez Khun -- > cmd.Parameters.AddWithValue("@id", id)
        // cela est deja protege par la toolbox
        public override AvisMembreBien GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idAvis", id);
            return base.getOne(Map, QueryParameters);
        }
        // pas besoin d'instancier Disco parce que MapToDico retourne Dictionnary 
        // nous avons besoin d'id de C# pour garder OUTPUT inserted.idAvis mais pour le momoent on ne l'utilise pas plus
        // 
        public override AvisMembreBien Insert(AvisMembreBien toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdAvis = id;
            return toInsert;
        }


        public override bool Update(AvisMembreBien toUpdate)
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
        private Dictionary<string, object> MapToDico(AvisMembreBien toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idAvis"] = toInsert.Id;
            p["note"] = toInsert.Note;
            p["message"] = toInsert.Message;
            p["idMembre"] = toInsert.IdMembre;
            p["idBien"] = toInsert.IdBien;
            p["DateAvis"] = toInsert.DateAvis;     
            p["Approuve"] = toInsert.Approuve;

            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme Titre qu'il ya dans la base de donnees 
        private AvisMembreBien Map(SqlDataReader arg)
        {
            return new AvisMembreBien()
            {
                IdAvis = (int)arg["idAvis"],
                Note = (int)arg["note"],
                Message = arg["message"].ToString(),
                IdMembre = (int)arg["idMembre"],
                IdBien = (int)arg["idBien"],
                DateAvis = (DateTime)arg["DateAvis"],
                Approuve = (bool)arg["Approuve"]

            };
        }
        #endregion

    }
}
