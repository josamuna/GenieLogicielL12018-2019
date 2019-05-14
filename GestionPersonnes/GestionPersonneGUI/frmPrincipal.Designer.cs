namespace GestionPersonneGUI
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.smConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.smDisconnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.smCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.smExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnData = new System.Windows.Forms.ToolStripMenuItem();
            this.smPersons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.smListPersons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.smToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.smStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.smAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tblConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tblPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.stStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.mnData,
            this.mnParameters,
            this.mnHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(863, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smConnection,
            this.smDisconnection,
            this.toolStripSeparator3,
            this.smCloseAll,
            this.toolStripSeparator4,
            this.smExit});
            this.mnFile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(54, 20);
            this.mnFile.Text = "&Fichier";
            // 
            // smConnection
            // 
            this.smConnection.Image = global::GestionPersonneGUI.Properties.Resources.connection;
            this.smConnection.ImageTransparentColor = System.Drawing.Color.Black;
            this.smConnection.Name = "smConnection";
            this.smConnection.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.smConnection.Size = new System.Drawing.Size(208, 22);
            this.smConnection.Text = "&Connexion";
            this.smConnection.Click += new System.EventHandler(this.smConnection_Click);
            // 
            // smDisconnection
            // 
            this.smDisconnection.Image = global::GestionPersonneGUI.Properties.Resources.Disconnection;
            this.smDisconnection.ImageTransparentColor = System.Drawing.Color.Black;
            this.smDisconnection.Name = "smDisconnection";
            this.smDisconnection.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.smDisconnection.Size = new System.Drawing.Size(208, 22);
            this.smDisconnection.Text = "&Déconnexion";
            this.smDisconnection.Click += new System.EventHandler(this.smDisconnection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // smCloseAll
            // 
            this.smCloseAll.Name = "smCloseAll";
            this.smCloseAll.Size = new System.Drawing.Size(208, 22);
            this.smCloseAll.Text = "Fermer Tous";
            this.smCloseAll.Click += new System.EventHandler(this.smCloseAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // smExit
            // 
            this.smExit.Name = "smExit";
            this.smExit.Size = new System.Drawing.Size(208, 22);
            this.smExit.Text = "&Quitter";
            this.smExit.Click += new System.EventHandler(this.smExit_Click);
            // 
            // mnData
            // 
            this.mnData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smPersons,
            this.toolStripSeparator6,
            this.smListPersons});
            this.mnData.Name = "mnData";
            this.mnData.Size = new System.Drawing.Size(65, 20);
            this.mnData.Text = "&Données";
            // 
            // smPersons
            // 
            this.smPersons.Image = global::GestionPersonneGUI.Properties.Resources.personnes;
            this.smPersons.ImageTransparentColor = System.Drawing.Color.Black;
            this.smPersons.Name = "smPersons";
            this.smPersons.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
            this.smPersons.Size = new System.Drawing.Size(249, 22);
            this.smPersons.Text = "&Personnes";
            this.smPersons.Click += new System.EventHandler(this.smPersons_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(246, 6);
            // 
            // smListPersons
            // 
            this.smListPersons.Image = global::GestionPersonneGUI.Properties.Resources._14;
            this.smListPersons.Name = "smListPersons";
            this.smListPersons.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.smListPersons.Size = new System.Drawing.Size(249, 22);
            this.smListPersons.Text = "Liste des personnes";
            this.smListPersons.Click += new System.EventHandler(this.smListPersons_Click);
            // 
            // mnParameters
            // 
            this.mnParameters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smToolbar,
            this.smStatusBar});
            this.mnParameters.Name = "mnParameters";
            this.mnParameters.Size = new System.Drawing.Size(78, 20);
            this.mnParameters.Text = "&Paramètres";
            // 
            // smToolbar
            // 
            this.smToolbar.Checked = true;
            this.smToolbar.CheckOnClick = true;
            this.smToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smToolbar.Name = "smToolbar";
            this.smToolbar.Size = new System.Drawing.Size(138, 22);
            this.smToolbar.Text = "&Barre d\'outil";
            this.smToolbar.Click += new System.EventHandler(this.smToolbar_Click);
            // 
            // smStatusBar
            // 
            this.smStatusBar.Checked = true;
            this.smStatusBar.CheckOnClick = true;
            this.smStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smStatusBar.Name = "smStatusBar";
            this.smStatusBar.Size = new System.Drawing.Size(138, 22);
            this.smStatusBar.Text = "Barre d\'ét&at";
            this.smStatusBar.Click += new System.EventHandler(this.smStatusBar_Click);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(43, 20);
            this.mnHelp.Text = "Aid&e";
            // 
            // smAbout
            // 
            this.smAbout.Name = "smAbout";
            this.smAbout.Size = new System.Drawing.Size(146, 22);
            this.smAbout.Text = "&A Propos ... ...";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblConnection,
            this.toolStripSeparator1,
            this.tblPreview,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(863, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tblConnection
            // 
            this.tblConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblConnection.Image = global::GestionPersonneGUI.Properties.Resources.connection;
            this.tblConnection.ImageTransparentColor = System.Drawing.Color.Black;
            this.tblConnection.Name = "tblConnection";
            this.tblConnection.Size = new System.Drawing.Size(23, 22);
            this.tblConnection.Text = "New";
            this.tblConnection.Click += new System.EventHandler(this.tblConnection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tblPreview
            // 
            this.tblPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblPreview.Image = ((System.Drawing.Image)(resources.GetObject("tblPreview.Image")));
            this.tblPreview.ImageTransparentColor = System.Drawing.Color.Black;
            this.tblPreview.Name = "tblPreview";
            this.tblPreview.Size = new System.Drawing.Size(23, 22);
            this.tblPreview.Text = "Print Preview";
            this.tblPreview.Click += new System.EventHandler(this.tblPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stStatus
            // 
            this.stStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.stStatus.Location = new System.Drawing.Point(0, 431);
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(863, 22);
            this.stStatus.TabIndex = 2;
            this.stStatus.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 17);
            this.lblStatus.Text = "Gestion des personnes";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 453);
            this.Controls.Add(this.stStatus);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.Text = "Interface principale de gestion des personnes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.stStatus.ResumeLayout(false);
            this.stStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip stStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem smAbout;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem smConnection;
        private System.Windows.Forms.ToolStripMenuItem smDisconnection;
        private System.Windows.Forms.ToolStripMenuItem smExit;
        private System.Windows.Forms.ToolStripMenuItem mnData;
        private System.Windows.Forms.ToolStripMenuItem smPersons;
        private System.Windows.Forms.ToolStripMenuItem mnParameters;
        private System.Windows.Forms.ToolStripMenuItem smToolbar;
        private System.Windows.Forms.ToolStripMenuItem smStatusBar;
        private System.Windows.Forms.ToolStripMenuItem mnHelp;
        private System.Windows.Forms.ToolStripButton tblConnection;
        private System.Windows.Forms.ToolStripButton tblPreview;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem smCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem smListPersons;
    }
}



