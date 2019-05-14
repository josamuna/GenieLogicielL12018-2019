namespace GestionPersonneGUI
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rpvPersonne = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvPersonne
            // 
            this.rpvPersonne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvPersonne.Location = new System.Drawing.Point(0, 0);
            this.rpvPersonne.Name = "rpvPersonne";
            this.rpvPersonne.Size = new System.Drawing.Size(978, 548);
            this.rpvPersonne.TabIndex = 0;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 548);
            this.Controls.Add(this.rpvPersonne);
            this.MaximizeBox = false;
            this.Name = "frmReport";
            this.Text = "Rapport pour liste des personnes";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPersonne;
    }
}