namespace Tester_Documents
{
    partial class FO_Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FO_Main));
            this.pan_top = new System.Windows.Forms.Panel();
            this.tbx_folder_in = new System.Windows.Forms.TextBox();
            this.btn_configuracao = new System.Windows.Forms.Button();
            this.btn_folder = new System.Windows.Forms.Button();
            this.lbl_file_in = new System.Windows.Forms.Label();
            this.pan_tot = new System.Windows.Forms.Panel();
            this.btn_create = new System.Windows.Forms.Button();
            this.tbx_folder_out = new System.Windows.Forms.TextBox();
            this.btn_folder_out = new System.Windows.Forms.Button();
            this.lbl_out = new System.Windows.Forms.Label();
            this.pan_top.SuspendLayout();
            this.pan_tot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_top
            // 
            this.pan_top.Controls.Add(this.tbx_folder_in);
            this.pan_top.Controls.Add(this.btn_configuracao);
            this.pan_top.Controls.Add(this.btn_folder);
            this.pan_top.Controls.Add(this.lbl_file_in);
            this.pan_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_top.Location = new System.Drawing.Point(0, 0);
            this.pan_top.Name = "pan_top";
            this.pan_top.Size = new System.Drawing.Size(312, 62);
            this.pan_top.TabIndex = 0;
            this.pan_top.DoubleClick += new System.EventHandler(this.pan_top_DoubleClick);
            // 
            // tbx_folder_in
            // 
            this.tbx_folder_in.Location = new System.Drawing.Point(16, 31);
            this.tbx_folder_in.Name = "tbx_folder_in";
            this.tbx_folder_in.Size = new System.Drawing.Size(234, 20);
            this.tbx_folder_in.TabIndex = 3;
            // 
            // btn_configuracao
            // 
            this.btn_configuracao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_configuracao.BackgroundImage")));
            this.btn_configuracao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_configuracao.Location = new System.Drawing.Point(283, 5);
            this.btn_configuracao.Name = "btn_configuracao";
            this.btn_configuracao.Size = new System.Drawing.Size(20, 20);
            this.btn_configuracao.TabIndex = 4;
            this.btn_configuracao.UseVisualStyleBackColor = true;
            this.btn_configuracao.Click += new System.EventHandler(this.btn_configuracao_Click);
            // 
            // btn_folder
            // 
            this.btn_folder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_folder.Location = new System.Drawing.Point(257, 31);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(46, 20);
            this.btn_folder.TabIndex = 4;
            this.btn_folder.Text = "File";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // lbl_file_in
            // 
            this.lbl_file_in.AutoSize = true;
            this.lbl_file_in.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_file_in.Location = new System.Drawing.Point(12, 9);
            this.lbl_file_in.Name = "lbl_file_in";
            this.lbl_file_in.Size = new System.Drawing.Size(126, 16);
            this.lbl_file_in.TabIndex = 0;
            this.lbl_file_in.Text = "XML file to be impot";
            // 
            // pan_tot
            // 
            this.pan_tot.Controls.Add(this.btn_create);
            this.pan_tot.Controls.Add(this.tbx_folder_out);
            this.pan_tot.Controls.Add(this.btn_folder_out);
            this.pan_tot.Controls.Add(this.lbl_out);
            this.pan_tot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tot.Location = new System.Drawing.Point(0, 62);
            this.pan_tot.Name = "pan_tot";
            this.pan_tot.Size = new System.Drawing.Size(312, 107);
            this.pan_tot.TabIndex = 1;
            // 
            // btn_create
            // 
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_create.Location = new System.Drawing.Point(16, 63);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(287, 32);
            this.btn_create.TabIndex = 8;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tbx_folder_out
            // 
            this.tbx_folder_out.Location = new System.Drawing.Point(16, 25);
            this.tbx_folder_out.Name = "tbx_folder_out";
            this.tbx_folder_out.Size = new System.Drawing.Size(234, 20);
            this.tbx_folder_out.TabIndex = 6;
            // 
            // btn_folder_out
            // 
            this.btn_folder_out.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_folder_out.Location = new System.Drawing.Point(257, 25);
            this.btn_folder_out.Name = "btn_folder_out";
            this.btn_folder_out.Size = new System.Drawing.Size(46, 20);
            this.btn_folder_out.TabIndex = 7;
            this.btn_folder_out.Text = "Folder";
            this.btn_folder_out.UseVisualStyleBackColor = true;
            this.btn_folder_out.Click += new System.EventHandler(this.btn_folder_out_Click);
            // 
            // lbl_out
            // 
            this.lbl_out.AutoSize = true;
            this.lbl_out.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_out.Location = new System.Drawing.Point(12, 3);
            this.lbl_out.Name = "lbl_out";
            this.lbl_out.Size = new System.Drawing.Size(113, 16);
            this.lbl_out.TabIndex = 5;
            this.lbl_out.Text = "Directory to saved";
            // 
            // FO_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(312, 169);
            this.Controls.Add(this.pan_tot);
            this.Controls.Add(this.pan_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FO_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Creater";
            this.pan_top.ResumeLayout(false);
            this.pan_top.PerformLayout();
            this.pan_tot.ResumeLayout(false);
            this.pan_tot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_top;
        private System.Windows.Forms.Panel pan_tot;
        private System.Windows.Forms.TextBox tbx_folder_in;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.Label lbl_file_in;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tbx_folder_out;
        private System.Windows.Forms.Button btn_folder_out;
        private System.Windows.Forms.Label lbl_out;
        private System.Windows.Forms.Button btn_configuracao;
    }
}

