namespace CaseMaker
{
    partial class FO_Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FO_Principal));
            this.pan_left = new System.Windows.Forms.Panel();
            this.pan_projetos = new System.Windows.Forms.Panel();
            this.trv_projetos = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pan_opções = new System.Windows.Forms.Panel();
            this.btn_novo_projeto = new System.Windows.Forms.Button();
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.lbl_título = new System.Windows.Forms.Label();
            this.pan_principal = new System.Windows.Forms.Panel();
            this.tbc_table_control = new System.Windows.Forms.TabControl();
            this.mst_opcoes = new System.Windows.Forms.MenuStrip();
            this.tsm_opcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_gerar_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_buscar_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_tipLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_log_simples = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_log_detalhado = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_left.SuspendLayout();
            this.pan_projetos.SuspendLayout();
            this.pan_opções.SuspendLayout();
            this.pan_titulo.SuspendLayout();
            this.pan_principal.SuspendLayout();
            this.mst_opcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_left
            // 
            this.pan_left.Controls.Add(this.pan_projetos);
            this.pan_left.Controls.Add(this.pan_opções);
            this.pan_left.Controls.Add(this.pan_titulo);
            this.pan_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_left.Location = new System.Drawing.Point(0, 0);
            this.pan_left.Name = "pan_left";
            this.pan_left.Size = new System.Drawing.Size(246, 606);
            this.pan_left.TabIndex = 0;
            // 
            // pan_projetos
            // 
            this.pan_projetos.Controls.Add(this.trv_projetos);
            this.pan_projetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_projetos.Location = new System.Drawing.Point(0, 59);
            this.pan_projetos.Name = "pan_projetos";
            this.pan_projetos.Size = new System.Drawing.Size(246, 508);
            this.pan_projetos.TabIndex = 1;
            // 
            // trv_projetos
            // 
            this.trv_projetos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.trv_projetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_projetos.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.trv_projetos.ImageIndex = 0;
            this.trv_projetos.ImageList = this.imgList;
            this.trv_projetos.Location = new System.Drawing.Point(0, 0);
            this.trv_projetos.Name = "trv_projetos";
            this.trv_projetos.SelectedImageIndex = 0;
            this.trv_projetos.Size = new System.Drawing.Size(246, 508);
            this.trv_projetos.TabIndex = 0;
            this.trv_projetos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_projetos_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "2909920x20.ico");
            this.imgList.Images.SetKeyName(1, "3106120x20.ico");
            this.imgList.Images.SetKeyName(2, "images20x20.ico");
            this.imgList.Images.SetKeyName(3, "branco20x20.ico");
            // 
            // pan_opções
            // 
            this.pan_opções.Controls.Add(this.btn_novo_projeto);
            this.pan_opções.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_opções.Location = new System.Drawing.Point(0, 567);
            this.pan_opções.Name = "pan_opções";
            this.pan_opções.Size = new System.Drawing.Size(246, 39);
            this.pan_opções.TabIndex = 0;
            // 
            // btn_novo_projeto
            // 
            this.btn_novo_projeto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_novo_projeto.Location = new System.Drawing.Point(3, 5);
            this.btn_novo_projeto.Name = "btn_novo_projeto";
            this.btn_novo_projeto.Size = new System.Drawing.Size(240, 31);
            this.btn_novo_projeto.TabIndex = 0;
            this.btn_novo_projeto.Text = "Novo";
            this.btn_novo_projeto.UseVisualStyleBackColor = true;
            this.btn_novo_projeto.Click += new System.EventHandler(this.btn_novo_projeto_Click);
            // 
            // pan_titulo
            // 
            this.pan_titulo.Controls.Add(this.lbl_título);
            this.pan_titulo.Controls.Add(this.mst_opcoes);
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(246, 59);
            this.pan_titulo.TabIndex = 2;
            // 
            // lbl_título
            // 
            this.lbl_título.AutoSize = true;
            this.lbl_título.Location = new System.Drawing.Point(12, 41);
            this.lbl_título.Name = "lbl_título";
            this.lbl_título.Size = new System.Drawing.Size(64, 16);
            this.lbl_título.TabIndex = 0;
            this.lbl_título.Text = "Relatórios";
            // 
            // pan_principal
            // 
            this.pan_principal.Controls.Add(this.tbc_table_control);
            this.pan_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_principal.Location = new System.Drawing.Point(246, 0);
            this.pan_principal.Name = "pan_principal";
            this.pan_principal.Size = new System.Drawing.Size(864, 606);
            this.pan_principal.TabIndex = 1;
            // 
            // tbc_table_control
            // 
            this.tbc_table_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_table_control.Location = new System.Drawing.Point(0, 0);
            this.tbc_table_control.Name = "tbc_table_control";
            this.tbc_table_control.SelectedIndex = 0;
            this.tbc_table_control.Size = new System.Drawing.Size(864, 606);
            this.tbc_table_control.TabIndex = 0;
            // 
            // mst_opcoes
            // 
            this.mst_opcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_opcoes});
            this.mst_opcoes.Location = new System.Drawing.Point(0, 0);
            this.mst_opcoes.Name = "mst_opcoes";
            this.mst_opcoes.Size = new System.Drawing.Size(246, 24);
            this.mst_opcoes.TabIndex = 1;
            this.mst_opcoes.Text = "menuStrip1";
            // 
            // tsm_opcoes
            // 
            this.tsm_opcoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_gerar_backup,
            this.tsp_buscar_backup,
            this.tsp_tipLog});
            this.tsm_opcoes.Name = "tsm_opcoes";
            this.tsm_opcoes.Size = new System.Drawing.Size(59, 20);
            this.tsm_opcoes.Text = "Opções";
            // 
            // tsp_gerar_backup
            // 
            this.tsp_gerar_backup.Name = "tsp_gerar_backup";
            this.tsp_gerar_backup.Size = new System.Drawing.Size(151, 22);
            this.tsp_gerar_backup.Text = "Gerar Backup";
            // 
            // tsp_buscar_backup
            // 
            this.tsp_buscar_backup.Name = "tsp_buscar_backup";
            this.tsp_buscar_backup.Size = new System.Drawing.Size(151, 22);
            this.tsp_buscar_backup.Text = "Buscar Backup";
            // 
            // tsp_tipLog
            // 
            this.tsp_tipLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_log_simples,
            this.tsp_log_detalhado});
            this.tsp_tipLog.Name = "tsp_tipLog";
            this.tsp_tipLog.Size = new System.Drawing.Size(151, 22);
            this.tsp_tipLog.Text = "Log";
            // 
            // tsp_log_simples
            // 
            this.tsp_log_simples.Name = "tsp_log_simples";
            this.tsp_log_simples.Size = new System.Drawing.Size(128, 22);
            this.tsp_log_simples.Text = "Simples";
            // 
            // tsp_log_detalhado
            // 
            this.tsp_log_detalhado.Name = "tsp_log_detalhado";
            this.tsp_log_detalhado.Size = new System.Drawing.Size(128, 22);
            this.tsp_log_detalhado.Text = "Detalhado";
            // 
            // FO_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1110, 606);
            this.Controls.Add(this.pan_principal);
            this.Controls.Add(this.pan_left);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1126, 644);
            this.Name = "FO_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Case Maker";
            this.pan_left.ResumeLayout(false);
            this.pan_projetos.ResumeLayout(false);
            this.pan_opções.ResumeLayout(false);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            this.pan_principal.ResumeLayout(false);
            this.mst_opcoes.ResumeLayout(false);
            this.mst_opcoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_left;
        private System.Windows.Forms.Panel pan_opções;
        private System.Windows.Forms.Panel pan_principal;
        private System.Windows.Forms.TabControl tbc_table_control;
        private System.Windows.Forms.Panel pan_projetos;
        private System.Windows.Forms.TreeView trv_projetos;
        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Button btn_novo_projeto;
        private System.Windows.Forms.Label lbl_título;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.MenuStrip mst_opcoes;
        private System.Windows.Forms.ToolStripMenuItem tsm_opcoes;
        private System.Windows.Forms.ToolStripMenuItem tsp_gerar_backup;
        private System.Windows.Forms.ToolStripMenuItem tsp_buscar_backup;
        private System.Windows.Forms.ToolStripMenuItem tsp_tipLog;
        private System.Windows.Forms.ToolStripMenuItem tsp_log_simples;
        private System.Windows.Forms.ToolStripMenuItem tsp_log_detalhado;
    }
}

