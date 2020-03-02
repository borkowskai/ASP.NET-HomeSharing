using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public class OptionRepository :BaseRepository<Option, int>
    {
        public OptionRepository(string Cnstr) : base(Cnstr)
        {
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM Option WHERE idOption=@idOption;";
            SelectAllCommand = "SELECT * FROM Option;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idMembre equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  Option (Libelle )
                            OUTPUT inserted.idOption VALUES(@Libelle;";
            UpdateCommand = @"UPDATE  Option
                           SET Libelle=@Libelle 
                         WHERE IdOption = @IdOption;";
            DeleteCommand = @"DELETE FROM Option  WHERE IdOption = @IdOption;";
        }





        public override IEnumerable<Option> GetAll()
        {
            return base.getAll(Map);
        }

        public override Option GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idOption", id);
            return base.getOne(Map, QueryParameters);
        }


        public override Option Insert(Option toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdOption = id;
            return toInsert;
        }


        public override bool Update(Option toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdOption", id);
            return base.Delete(QueryParameters);

        }

        public IEnumerable<Option> GetCountries()
        {
            SelectAllCommand = "SELECT * FROM Option ORDER BY Libelle";
            return base.getAll(Map);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Option toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idOption"] = toInsert.Id;
            //cela pourrait etre p.Add()
            p["Libelle"] = toInsert.Libelle;
            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme nom qu'il ya dans la base de donnees 
        private Option Map(SqlDataReader arg)
        {
            return new Option()
            {
                IdOption = (int)arg["idOption"],
                Libelle = arg["Libelle"].ToString()
            };
        }
        #endregion

    }
}
