using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public class PaysRepository :BaseRepository<Pays, int>
    {
        public PaysRepository(string Cnstr) : base(Cnstr)
        {
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM Pays WHERE idPays=@idPays;";
            SelectAllCommand = "SELECT * FROM Pays;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idMembre equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  Pays (Libelle ,Photo)
                            OUTPUT inserted.idPays VALUES(@Libelle ,@Photo;";
            UpdateCommand = @"UPDATE  Pays
                           SET Libelle=@Libelle , Photo=@Photo
                         WHERE IdPays = @IdPays;";
            DeleteCommand = @"DELETE FROM Pays  WHERE IdPays = @IdPays;";
        }





        public override IEnumerable<Pays> GetAll()
        {
            return base.getAll(Map);
        }

        public override Pays GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idPays", id);
            return base.getOne(Map, QueryParameters);
        }


        public override Pays Insert(Pays toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdPays = id;
            return toInsert;
        }


        public override bool Update(Pays toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdPays", id);
            return base.Delete(QueryParameters);

        }

        public IEnumerable<Pays> GetCountries()
        {
            SelectAllCommand = "SELECT * FROM Pays ORDER BY Libelle";
            return base.getAll(Map);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Pays toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idPays"] = toInsert.Id;
            //cela pourrait etre p.Add()
            p["Libelle"] = toInsert.Libelle;
            p["Photo"] = toInsert.Photo;
            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme nom qu'il ya dans la base de donnees 
        private Pays Map(SqlDataReader arg)
        {
            return new Pays()
            {
                IdPays = (int)arg["idPays"],
                Libelle = arg["Libelle"].ToString(),
                Photo = arg["Photo"].ToString(),
            };
        }
        #endregion


    }
}
