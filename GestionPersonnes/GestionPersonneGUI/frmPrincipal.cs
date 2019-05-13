using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPersonneGUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void smCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form formEnfant in MdiChildren)
            {
                formEnfant.Close();
            }
        }

        private void smToolbar_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = smToolbar.Checked;
        }

        private void smStatusBar_Click(object sender, EventArgs e)
        {
            stStatus.Visible = smStatusBar.Checked;
        }
    }
}
