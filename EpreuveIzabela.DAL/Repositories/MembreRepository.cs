using EpreuveIzabela.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Repositories
{
    public class MembreRepository : BaseRepository<Membre, int>
    {

        public MembreRepository(string Cnstr) : base(Cnstr)
        {
            //majuscule ou miniscule dans les requetes pas vraiment importance pour SQL 
            SelectOneCommand = "SELECT * FROM Membre WHERE idMembre=@idMembre;";
            SelectAllCommand = "SELECT * FROM Membre;";
            //@ pour permettre ecrire dans plusieurs lignes sans concatenation automatique
            // OUTPUT inserted.idMembre equivalant de last id en PHP
            InsertCommand = @"INSERT INTO  Membre (Nom ,Prenom ,Email, Pays, Telephone, Login, Password, PhotoUser, IsDeleted)
                            OUTPUT inserted.idMembre VALUES(@Nom ,@Prenom ,@Email, @Pays, @Telephone, @Login, @Password, @PhotoUser, @IsDeleted);";
            UpdateCommand = @"UPDATE  Membre
                           SET Nom=@Nom ,Prenom=@Prenom ,Email=@Email, Pays=@Pays, Telephone=@Telephone, Login=@Login,Password=@Password, PhotoUser=@PhotoUser, IsDeleted=@IsDeleted
                         WHERE IdMembre = @IdMembre;";
            DeleteCommand = @"DELETE FROM Membre  WHERE IdMembre = @IdMembre;";
        }



        public Membre VerifLogin(Membre membre)
        {
            SelectOneCommand = "SELECT * FROM Membre WHERE Login=@Login and Password=@Password";
            return base.getOne(Map, MapToDico(membre));
        }

        public override IEnumerable<Membre> GetAll()
        {
            return base.getAll(Map);
        }
        // @id n'est pas necessaire comme chez Khun -- > cmd.Parameters.AddWithValue("@id", id)
        // cela est deja protege par la toolbox
        public override Membre GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idMembre", id);
            return base.getOne(Map, QueryParameters);
        }
        // pas besoin d'instancier Disco parce que MapToDico retourne Dictionnary 
        // nous avons besoin d'id de C# pour garder OUTPUT inserted.idMembre mais pour le momoent on ne l'utilise pas plus
        // 
        public override Membre Insert(Membre toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdMembre = id;
            return toInsert;
        }


        public override bool Update(Membre toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdMembre", id);
            return base.Delete(QueryParameters);

        }

        public IEnumerable<Bien>LoadBien(int id)
        {
            BienRepository br = new BienRepository(this._Cnstr);
            return br.GetBiensFromMembre(id);
        }

        #region Mappers
        private Dictionary<string, object> MapToDico(Membre toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idMembre"] = toInsert.Id;
            //cela pourrait etre p.Add()
            p["Nom"] = toInsert.Nom;
            p["Prenom"] = toInsert.Prenom;
            p["Email"] = toInsert.Email;
            p["Pays"] = toInsert.Pays;
            p["Telephone"] = toInsert.Telephone;
            p["Login"] = toInsert.Login;
            //p["Password"] = toInsert.Password;
            //c'est ici que l'on dit que le mdp doit etre stocke en version hache
            //debloquer apres les tests
            p["Password"] = toInsert.HashMDP;
            p["PhotoUser"] = toInsert.PhotoUser;
            //TODO verifier si IsDeleted est necessaire
            p["isDeleted"] = toInsert.IsDeleted;

            return p;
        }

        //les crochers c'est les key de dictionnaire que SqlDataReader ou DBDataReader
        //qui cherche le meme nom qu'il ya dans la base de donnees 
        private Membre Map(SqlDataReader arg)
        {
            return new Membre()
            {
                IdMembre = (int)arg["idMembre"],
                Nom = arg["Nom"].ToString(),
                Prenom = arg["Prenom"].ToString(),
                Email = arg["Email"].ToString(),
                Pays = (int)arg["Pays"],
                Telephone = arg["Telephone"].ToString(),
                Login = arg["Login"].ToString(),
                //supprimer a cause de hashage //WE CAN'T STORE PASSWORD FROM DB
                //Password = arg["Password"].ToString(),
                PhotoUser = arg["PhotoUser"].ToString(),
                IsDeleted = (bool)arg["isDeleted"]
            };
        }
        #endregion


    }
}
