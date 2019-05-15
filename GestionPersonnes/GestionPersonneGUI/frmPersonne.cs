using GestionPersonneLib;
using ManageSingleConnexion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionPersonneGUI
{
    public partial class frmPersonne : Form
    {
        //Declaration BindingSource pour les BindingNavigator

        private BindingSource bdsrc1 = new BindingSource();
        private BindingSource bdsrc2 = new BindingSource();

        private int? _id_personne = null;
        public frmPersonne()
        {
            InitializeComponent();
        }

        private void refreshPersonne(IPersonne personne)
        {
            List<IPersonne> lst = new List<IPersonne>();
            lst = personne.Personnes();

            //Chargement BindingSource avec la liste des personne
            bdsrc1.DataSource = lst;
            // Le datasource du DataGrid devient le BindingSource pour faciliter la progression en accord dans ce dernier
            dgvPersonne.DataSource = bdsrc1;
        }

        private void frmPersonne_Load(object sender, EventArgs e)
        {
            //Affectation BindingSource aux BindingNavigator
            bdnav1.BindingSource = bdsrc1;
            bdnav2.BindingSource = bdsrc2;

            // Charger les Sexes
            cboSexe.DataSource = Enum.GetNames(typeof(Sexe));
            cboSexe.SelectedIndex = 0;

            // Activation et desactivation boutons
            btnSave1.Enabled = false;
            btnDelete1.Enabled = false;

            btnSave2.Enabled = false;
            btnDelete2.Enabled = false;

            try
            {
                refreshPersonne(new Personne());                
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                txtName.Clear();
                txtPNane.Clear();
                txtPrenom.Clear();
                txtName.Focus();

                IPersonne personne = new Personne();
                txtID.Text = personne.Nouveau().ToString();

                // Activer bouton
                btnSave1.Enabled = true;
                btnDelete1.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                IPersonne personne = new Personne();

                personne.Id = Convert.ToInt32(txtID.Text);
                personne.Nom = txtName.Text;
                personne.Postnom = txtPNane.Text;
                personne.Prenom = txtPrenom.Text;
                personne.Sex = cboSexe.Text.Equals(Sexe.Masculin.ToString()) ? Sexe.Masculin : Sexe.Féminin;

                personne.Enregistrer(personne);

                MessageBox.Show("Record has been saved Successfuly !!!", "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshPersonne(personne);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                IPersonne personne = new Personne();

                personne.Id = Convert.ToInt32(txtID.Text);

                personne.Supprimer(personne.Id);

                MessageBox.Show("Record has been deleted successfuly !!!", "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshPersonne(personne);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void dgvPersonne_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvPersonne.SelectedRows.Count > 0)
                {
                    IPersonne personne = new Personne();

                    personne = (IPersonne)dgvPersonne.SelectedRows[0].DataBoundItem;

                    txtID.Text = personne.Id.ToString();
                    txtName.Text = personne.Nom;
                    txtPNane.Text = personne.Postnom;
                    txtPrenom.Text = personne.Prenom;
                    cboSexe.Text = personne.Sex == Sexe.Masculin ? Sexe.Masculin.ToString() : Sexe.Féminin.ToString();

                    _id_personne = personne.Id;

                    // Avant de charger les telephones on vide les champ des telephone
                    txtIDTel.Clear();
                    txtInitial.Clear();
                    txtNumero.Clear();

                    // Charger les telephones de la personnes
                    List<ITelephone> lst = new List<ITelephone>();

                    lst = personne.TelephonePersonnes;

                    // Chargement du BindinSource pour les telephones
                    bdsrc2.DataSource = lst;

                    // Le datasource du DataGrid devient le BindingSource pour faciliter la progression en accord dans ce dernier
                    dgvTelephone.DataSource = bdsrc2;

                    // Activer bouton
                    btnSave1.Enabled = true;
                    btnDelete1.Enabled = true;
                }
                else
                {
                    btnSave1.Enabled = false;
                    btnDelete1.Enabled = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
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
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                txtInitial.Clear();
                txtNumero.Clear();
                txtInitial.Focus();

                ITelephone telephone = new Telephone();
                txtIDTel.Text = telephone.Nouveau().ToString();

                // Activer bouton
                btnSave2.Enabled = true;
                btnDelete2.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                ITelephone telephone = new Telephone();

                telephone.Id = Convert.ToInt32(txtIDTel.Text);
                telephone.Id_proprietaire = Convert.ToInt32(_id_personne);
                telephone.Initial = txtInitial.Text;
                telephone.Numero = txtNumero.Text;

                telephone.Enregistrer(telephone);

                MessageBox.Show("Record has been saved Successfuly !!!", "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualisation de la liste des Telephone de la 
                // personne selectionnee

                dgvTelephone.DataSource = telephone.TelephonesPersonnes(Convert.ToInt32(_id_personne));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                ITelephone telephone = new Telephone();

                telephone.Id = Convert.ToInt32(txtIDTel.Text);

                telephone.Supprimer(telephone.Id);

                MessageBox.Show("Record has been deleted successfuly !!!", "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvTelephone.DataSource = telephone.TelephonesPersonnes(Convert.ToInt32(_id_personne));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when deleting datas, " + ex.Message, "Deleting datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }

        private void dgvTelephone_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTelephone.SelectedRows.Count > 0)
                {
                    ITelephone telephone = new Telephone();

                    telephone = (ITelephone)dgvTelephone.SelectedRows[0].DataBoundItem;

                    txtIDTel.Text = telephone.Id.ToString();
                    txtInitial.Text = telephone.Initial;
                    txtNumero.Text = telephone.Numero;

                    // Activer bouton
                    btnSave2.Enabled = true;
                    btnDelete2.Enabled = true;
                }
                else
                {
                    btnSave2.Enabled = false;
                    btnDelete2.Enabled = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
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
            }
        }
    }
}
