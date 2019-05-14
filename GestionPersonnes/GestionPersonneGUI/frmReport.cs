using System;
using ManageSingleConnexion;
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
            this.rpvPersonne.RefreshReport();
        }
    }
}
