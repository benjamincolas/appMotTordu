namespace lesMotsTordus
{
    partial class frmConnexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnexion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bddOff = new MetroFramework.Controls.MetroLabel();
            this.progressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.pctBxQuit = new System.Windows.Forms.PictureBox();
            this.lblErreurAuth = new MetroFramework.Controls.MetroLabel();
            this.lblQuitApp = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pctBxLogo = new System.Windows.Forms.PictureBox();
            this.pctBxPassword = new System.Windows.Forms.PictureBox();
            this.btnConnexion = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txtBxPassword = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtBxIdentifiant = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.bddOff);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.pctBxQuit);
            this.panel1.Controls.Add(this.lblErreurAuth);
            this.panel1.Controls.Add(this.lblQuitApp);
            this.panel1.Controls.Add(this.pctBxLogo);
            this.panel1.Controls.Add(this.pctBxPassword);
            this.panel1.Controls.Add(this.btnConnexion);
            this.panel1.Controls.Add(this.bunifuSeparator2);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.txtBxPassword);
            this.panel1.Controls.Add(this.txtBxIdentifiant);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 550);
            this.panel1.TabIndex = 1;
            // 
            // bddOff
            // 
            this.bddOff.AutoSize = true;
            this.bddOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.bddOff.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.bddOff.ForeColor = System.Drawing.Color.Red;
            this.bddOff.Location = new System.Drawing.Point(104, 215);
            this.bddOff.Name = "bddOff";
            this.bddOff.Size = new System.Drawing.Size(213, 19);
            this.bddOff.TabIndex = 10;
            this.bddOff.Text = "Base de données inaccessible !";
            this.bddOff.UseCustomBackColor = true;
            this.bddOff.UseCustomForeColor = true;
            this.bddOff.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Silver;
            this.progressBar.BorderRadius = 5;
            this.progressBar.Location = new System.Drawing.Point(0, 514);
            this.progressBar.MaximumValue = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.White;
            this.progressBar.Size = new System.Drawing.Size(401, 10);
            this.progressBar.TabIndex = 1;
            this.progressBar.TabStop = false;
            this.progressBar.Value = 0;
            this.progressBar.Visible = false;
            // 
            // pctBxQuit
            // 
            this.pctBxQuit.BackColor = System.Drawing.Color.Transparent;
            this.pctBxQuit.BackgroundImage = global::lesMotsTordus.Properties.Resources.fermer;
            this.pctBxQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctBxQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBxQuit.Location = new System.Drawing.Point(365, 0);
            this.pctBxQuit.Name = "pctBxQuit";
            this.pctBxQuit.Size = new System.Drawing.Size(36, 30);
            this.pctBxQuit.TabIndex = 119;
            this.pctBxQuit.TabStop = false;
            this.pctBxQuit.Click += new System.EventHandler(this.pctBxQuit_Click);
            // 
            // lblErreurAuth
            // 
            this.lblErreurAuth.AutoSize = true;
            this.lblErreurAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.lblErreurAuth.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblErreurAuth.ForeColor = System.Drawing.Color.Red;
            this.lblErreurAuth.Location = new System.Drawing.Point(81, 215);
            this.lblErreurAuth.Name = "lblErreurAuth";
            this.lblErreurAuth.Size = new System.Drawing.Size(264, 19);
            this.lblErreurAuth.TabIndex = 23;
            this.lblErreurAuth.Text = "Mot de passe ou identifiant incorrect !";
            this.lblErreurAuth.UseCustomBackColor = true;
            this.lblErreurAuth.UseCustomForeColor = true;
            this.lblErreurAuth.Visible = false;
            // 
            // lblQuitApp
            // 
            this.lblQuitApp.AutoSize = true;
            this.lblQuitApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuitApp.ForeColor = System.Drawing.Color.White;
            this.lblQuitApp.Location = new System.Drawing.Point(389, 0);
            this.lblQuitApp.Name = "lblQuitApp";
            this.lblQuitApp.Size = new System.Drawing.Size(27, 25);
            this.lblQuitApp.TabIndex = 22;
            this.lblQuitApp.Text = "X";
            // 
            // pctBxLogo
            // 
            this.pctBxLogo.BackgroundImage = global::lesMotsTordus.Properties.Resources.logo;
            this.pctBxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctBxLogo.Location = new System.Drawing.Point(110, 60);
            this.pctBxLogo.Name = "pctBxLogo";
            this.pctBxLogo.Size = new System.Drawing.Size(200, 140);
            this.pctBxLogo.TabIndex = 21;
            this.pctBxLogo.TabStop = false;
            // 
            // pctBxPassword
            // 
            this.pctBxPassword.BackgroundImage = global::lesMotsTordus.Properties.Resources.invisible;
            this.pctBxPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctBxPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBxPassword.Location = new System.Drawing.Point(316, 330);
            this.pctBxPassword.Name = "pctBxPassword";
            this.pctBxPassword.Size = new System.Drawing.Size(17, 17);
            this.pctBxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBxPassword.TabIndex = 20;
            this.pctBxPassword.TabStop = false;
            this.pctBxPassword.Visible = false;
            this.pctBxPassword.Click += new System.EventHandler(this.pctBxPassword_Click);
            // 
            // btnConnexion
            // 
            this.btnConnexion.ActiveBorderThickness = 1;
            this.btnConnexion.ActiveCornerRadius = 30;
            this.btnConnexion.ActiveFillColor = System.Drawing.Color.White;
            this.btnConnexion.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnConnexion.ActiveLineColor = System.Drawing.Color.White;
            this.btnConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnConnexion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConnexion.BackgroundImage")));
            this.btnConnexion.ButtonText = "Se connecter";
            this.btnConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnexion.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnConnexion.IdleBorderThickness = 1;
            this.btnConnexion.IdleCornerRadius = 30;
            this.btnConnexion.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnConnexion.IdleForecolor = System.Drawing.Color.White;
            this.btnConnexion.IdleLineColor = System.Drawing.Color.White;
            this.btnConnexion.Location = new System.Drawing.Point(110, 406);
            this.btnConnexion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(200, 50);
            this.btnConnexion.TabIndex = 3;
            this.btnConnexion.TabStop = false;
            this.btnConnexion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(110, 345);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(200, 10);
            this.bunifuSeparator2.TabIndex = 18;
            this.bunifuSeparator2.TabStop = false;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.White;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(110, 275);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(200, 14);
            this.bunifuSeparator1.TabIndex = 17;
            this.bunifuSeparator1.TabStop = false;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtBxPassword.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtBxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBxPassword.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxPassword.ForeColor = System.Drawing.Color.White;
            this.txtBxPassword.Location = new System.Drawing.Point(110, 320);
            this.txtBxPassword.MaxLength = 256;
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(200, 23);
            this.txtBxPassword.TabIndex = 2;
            this.txtBxPassword.Text = "Mot de passe";
            this.txtBxPassword.Click += new System.EventHandler(this.txtBxPassword_Click);
            this.txtBxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxPassword_KeyDown);
            this.txtBxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxPassword_KeyPress);
            // 
            // txtBxIdentifiant
            // 
            this.txtBxIdentifiant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtBxIdentifiant.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtBxIdentifiant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBxIdentifiant.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxIdentifiant.ForeColor = System.Drawing.Color.White;
            this.txtBxIdentifiant.Location = new System.Drawing.Point(110, 250);
            this.txtBxIdentifiant.MaxLength = 30;
            this.txtBxIdentifiant.Name = "txtBxIdentifiant";
            this.txtBxIdentifiant.Size = new System.Drawing.Size(200, 23);
            this.txtBxIdentifiant.TabIndex = 1;
            this.txtBxIdentifiant.Tag = "";
            this.txtBxIdentifiant.Text = "Identifiant";
            this.txtBxIdentifiant.Click += new System.EventHandler(this.txtBxIdentifiant_Click);
            this.txtBxIdentifiant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxIdentifiant_KeyPress);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConnexion";
            this.Resizable = false;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBxPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pctBxQuit;
        private MetroFramework.Controls.MetroLabel lblErreurAuth;
        private Bunifu.Framework.UI.BunifuCustomLabel lblQuitApp;
        private System.Windows.Forms.PictureBox pctBxLogo;
        private System.Windows.Forms.PictureBox pctBxPassword;
        private Bunifu.Framework.UI.BunifuThinButton2 btnConnexion;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtBxPassword;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtBxIdentifiant;
        private Bunifu.Framework.UI.BunifuProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private MetroFramework.Controls.MetroLabel bddOff;
    }
}