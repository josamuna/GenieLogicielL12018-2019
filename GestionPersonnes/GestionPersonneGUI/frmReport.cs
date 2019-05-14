using ManageSingleConnexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionPersonneGUI
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            /*this.rpvPersonne.RefreshReport();*/
            SqlDataAdapter adapter = null;
            DataSet dataset = null;

            try
            {
                if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();

                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "sp_liste_personnes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    adapter = new SqlDataAdapter((SqlCommand)cmd);

                    // Instentiation du DataSet
                    dataset = new DataSet();

                    // Remplissage du DataSet via Le SqlDataAdapter
                    adapter.Fill(dataset, "DataSet1");

                    // Debut du Chargement du raport via l'objet ReportViewer

                    // On vide le contenu du ReportViewer
                    rpvPersonne.LocalReport.DataSources.Clear();

                    // Donner la souce a notre ReportViewer
                    rpvPersonne.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataset.Tables[0]));

                    // Specifier le rapport a charger
                    rpvPersonne.LocalReport.ReportEmbeddedResource = "GestionPersonneGUI.Reports.ListePersonnes.rdlc";

                    // Chargement du rapport

                    rpvPersonne.RefreshReport();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }

                if (adapter != null)
                    adapter.Dispose();
                if (dataset != null)
                    dataset.Dispose();
            }
        }
    }
}
