using GestionPersonneUtilitiesLib;
using ManageSingleConnexion;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionPersonneLib
{
    public class Telephone : ITelephone
    {
        public Telephone()
        {
        }

        private int _id;
        private int _id_proprietaire;
        private string _initial;
        private string _numero;

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

        public int Id_proprietaire
        {
            get
            {
                return _id_proprietaire;
            }

            set
            {
                _id_proprietaire = value;
            }
        }

        public string Initial
        {
            get
            {
                return _initial;
            }

            set
            {
                if (value.Length > 4)
                    throw new InvalidOperationException("Please specify a valid initial with 4 characters");
                else
                    _initial = value;
            }
        }

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value.Length > 9)
                    throw new InvalidOperationException("Please specify a valid phone number with 9 characters");
                else
                    _numero = value;
            }
        }

        public string NumeroComplet
        {
            get
            {
                return this._initial + this._numero;
            }
        }

        public int Nouveau()
        {
            int id = 0;

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(id) as lastId from telephone";

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

        public void Enregistrer(ITelephone telephone)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_insert_telephone";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _id));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id_proprietaire", 4, DbType.Int32, _id_proprietaire));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@initial", 4, DbType.String, _initial));
                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@numero", 9, DbType.String, _numero));

                cmd.ExecuteNonQuery();
            }
        }

        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_delete_telephone";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _id));

                int record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("That id does not exist !!!");
            }
        }

        private ITelephone GetPhone(IDataReader rd)
        {
            ITelephone telephone = new Telephone();

            telephone.Id = int.Parse(rd["id"].ToString());
            telephone.Id_proprietaire = Convert.ToInt32(rd["id_proprietaire"].ToString());
            telephone.Initial = rd["initial"].ToString();
            telephone.Numero = rd["numero"].ToString();

            return telephone;
        }

        public List<ITelephone> Telephones()
        {
            List<ITelephone> lst = new List<ITelephone>();

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_select_telephones";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lst.Add(GetPhone(rd));
                }

                rd.Dispose();
            }

            return lst;
        }

        public ITelephone OneTelephone(int id)
        {
            ITelephone telephone = new Telephone();

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_select_telephone";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    telephone = GetPhone(rd);
                }

                rd.Dispose();
            }

            return telephone;
        }

        public List<ITelephone> TelephonesPersonnes(int id_personne)
        {
            List<ITelephone> lst = new List<ITelephone>();

            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();

            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "sp_select_telephones_personne";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametres.Instance.AjouterParametre(cmd, "@id_personne", 4, DbType.Int32, id_personne));

                IDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    lst.Add(GetPhone(rd));
                }

                rd.Dispose();
            }

            return lst;
        }
    }
}