using System;
using System.Data;

namespace ManageSingleConnexion
{
    internal interface IConnexion
    {
        IDbConnection Initialise(Connexion connexion, ConnexionType connectionType);
    }
}
