using ManageSingleConnexion;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ImplementeConnexion.Instance.ConType = ConnexionType.SQLServer;
            Connexion connection = new Connexion();

            connection.Serveur = @"JOSAM\SQLEXPRESS"; 
            connection.Database = "gestion_personne";
            connection.User = "sa";
            connection.Password = "isig";

            try
            {
                ImplementeConnexion.Instance.Initialise(connection);

                if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();

                Console.WriteLine("Connection Successfuly !!!");
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("Connection error, " + ex.Message);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Connection error, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error, " + ex.Message);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }

            Console.ReadLine();
        }
    }
}
