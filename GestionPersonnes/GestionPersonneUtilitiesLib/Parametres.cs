using System;
using System.Data;

namespace GestionPersonneUtilitiesLib
{
    public class Parametres
    {
        private Parametres()
        {
        }

        private static Parametres _instance = null;

        public static Parametres Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Parametres();
                return _instance;
            }
        }

        public IDbDataParameter AjouterParametre(IDbCommand command, string nomParametre, int taille, DbType type, object valeur)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = nomParametre;
            param.DbType = type;
            param.Size = taille;
            param.Value = valeur;

            return param;
        }
    }
}
