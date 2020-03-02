using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public class OptionBienRepository : BaseRepository<OptionBien, int>
    {
        public OptionBienRepository(string Cnstr) : base(Cnstr)
        {
            //TODO treat the double primary key

            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM OptionBien WHERE ?=@?;";
            SelectAllCommand = "SELECT * FROM OptionBien;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idMembre equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  OptionBien (Libelle ,Valeur)
                            OUTPUT inserted.? VALUES(@Libelle ,@Valeur;";
            UpdateCommand = @"UPDATE  OptionBien
                           SET Libelle=@Libelle , Valeur=@Valeur
                         WHERE ? = @?;";
            DeleteCommand = @"DELETE FROM OptionBien  WHERE ? = @?;";
        }





        public override IEnumerable<OptionBien> GetAll()
        {
            return base.getAll(Map);
        }

        public override OptionBien GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("?", id);
            return base.getOne(Map, QueryParameters);
        }


        public override OptionBien Insert(OptionBien toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            //TODO
            //toInsert.? = id;
            return toInsert;
        }


        public override bool Update(OptionBien toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@?", id);
            return base.Delete(QueryParameters);

        }

        //public IEnumerable<OptionBien> GetCountries()
        //{
        //    SelectAllCommand = "SELECT * FROM OptionBien ORDER BY Libelle";
        //    return base.getAll(Map);
        //}


        #region Mappers
        private Dictionary<string, object> MapToDico(OptionBien toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idOption"] = toInsert.IdOption;
            //cela pourrait etre p.Add()
            p["idBien"] = toInsert.IdBien;
            p["Valeur"] = toInsert.Valeur;
            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme nom qu'il ya dans la base de donnees 
        private OptionBien Map(SqlDataReader arg)
        {
            return new OptionBien()
            {
                IdOption = (int)arg["idOption"],
                IdBien = (int)arg["IdBien"],
                Valeur = arg["Valeur"].ToString(),
            };
        }
        #endregion


    }
}
