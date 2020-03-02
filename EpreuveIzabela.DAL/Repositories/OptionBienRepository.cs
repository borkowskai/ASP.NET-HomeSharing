using EpreuveIzabela.DAL.Infra;
using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public class OptionBienRepository : BaseRepository<OptionBien, CompositeKey<int, int>>
    {
        public OptionBienRepository(string Cnstr) : base(Cnstr)
        {
            //TODO treat the double primary key

            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM OptionBien WHERE idOption=@idOption AND idBien=@idBien;";
            SelectAllCommand = "SELECT * FROM OptionBien;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idMembre equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  OptionBien (idOption, idBien, Valeur)
                         VALUES(@idOption, @idBien, @Valeur);";
            UpdateCommand = @"UPDATE  OptionBien
                           SET idOption=@idOption, idBien=@idBien, Valeur=@Valeur
                         WHERE idOption=@idOption AND idBien=@idBien ;";
            DeleteCommand = @"DELETE FROM OptionBien  WHERE idOption=@idOption AND idBien=@idBien;";
        }





        public override IEnumerable<OptionBien> GetAll()
        {
            return base.getAll(Map);
        }

        public override OptionBien GetOne(CompositeKey<int, int> id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdOption", id.PK1);
            QueryParameters.Add("IdBien", id.PK2);
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

        public override bool Delete(CompositeKey<int, int> id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdOption", id.PK1);
            QueryParameters.Add("IdBien", id.PK2);
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
