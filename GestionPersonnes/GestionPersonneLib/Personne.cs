using GestionPersonneUtilitiesLib;
using ManageSingleConnexion;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionPersonneLib
{
    public class Personne:IPersonne
    {
        public Personne()
        {
        }

        private int _id;
        private string _nom;
        private string _postnom;
        private string _prenom;
        private Sexe _sex;
        private List<ITelephone> _telephonePersonnes;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = ValidateName(value);
            }
        }

        private string ValidateName(string nom)
        {
            if (!string.IsNullOrEmpty(nom))
            {
                if (!char.IsLetter(nom[0]))
                    throw new InvalidOperationException("Name must begin with letter !!!");
                else
                    return nom;
            }
            else
                throw new InvalidOperationException("Name must have value !!!");
        }

        public string Postnom
        {
            get
            {
                return _postnom;
            }

            set
            {
                _postnom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public Sexe Sex
        {
            get
            {
                return _sex;
            }

            set
            {
                _sex = value;
            }
        }

        public List<ITelephone> TelephonePersonnes
        {
            get
            {
                List<ITelephone> telephones = new List<ITelephone>();

                ITelephone phone = new Telephone();

                telephones.Clear();
                telephones = phone.TelephonesPersonnes(_id);

                return telephones;
            }
        }

        public int Nouveau()
        {
            int id = 0;

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(id) as lastId from personne";

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    if (rd["lastId"] == DBNull.Value)
                        id = 1;
                    else
                        id = Convert.ToInt32(rd["lastId"].ToString()) + 1;
                }

                rd.Dispose();
            }

            return id;
        }

        public void Enregistrer(IPersonne personne)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_insert_personne";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _id));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@nom", 50, DbType.String, _nom));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@postnom", 50, DbType.String, _postnom));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@prenom", 50, DbType.String, _prenom));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@sexe", 1, DbType.String, _sex == Sexe.Féminin ? "F" : "M"));

                cmd.ExecuteNonQuery();
            }
        }

        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_delete_personne";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _id));

                int record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("That id does not exist !!!");
            }
        }

        public List<IPersonne> Personnes()
        {
            List<IPersonne> lst = new List<IPersonne>();

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_select_personnes";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lst.Add(GetPersonne(rd));
                }

                rd.Dispose();
            }

            return lst;
        }

        private IPersonne GetPersonne(IDataReader rd)
        {
            IPersonne personne = new Personne();

            personne.Id = Convert.ToInt32(rd["id"].ToString());
            personne.Nom = rd["nom"].ToString();
            personne.Postnom = rd["postnom"].ToString();
            personne.Prenom = rd["prenom"].ToString();
            personne.Sex = rd["sexe"].ToString().Equals("M") ? Sexe.Masculin : Sexe.Féminin;

            return personne;
        }

        public IPersonne OnePersonne(int id)
        {
            IPersonne personne = new Personne();

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_select_personne";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    personne = GetPersonne(rd);
                }

                rd.Dispose();
            }
            
            return personne;
        }

        public override string ToString()
        {
            return (_nom + " " + (string.IsNullOrEmpty(_postnom) ? "" : _postnom + " ") + _prenom).Trim();
        }
    }
}
