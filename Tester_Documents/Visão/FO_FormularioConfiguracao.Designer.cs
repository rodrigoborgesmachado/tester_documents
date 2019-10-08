namespace Tester_Documents.Visão
{
    partial class FO_FormularioConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FO_FormularioConfiguracao));
            this.pan_completo = new System.Windows.Forms.Panel();
            this.pan_tot = new System.Windows.Forms.Panel();
            this.gpb_grupo_cadastro = new System.Windows.Forms.GroupBox();
            this.dtp_data_alteracao = new System.Windows.Forms.DateTimePicker();
            this.dtp_data_criacao = new System.Windows.Forms.DateTimePicker();
            this.tbx_log = new System.Windows.Forms.TextBox();
            this.tbx_keywords = new System.Windows.Forms.TextBox();
            this.tbx_titulo = new System.Windows.Forms.TextBox();
            this.tbx_subject = new System.Windows.Forms.TextBox();
            this.tbx_creator = new System.Windows.Forms.TextBox();
            this.lbl_data_alteracao = new System.Windows.Forms.Label();
            this.lbl_log = new System.Windows.Forms.Label();
            this.lbl_keywords = new System.Windows.Forms.Label();
            this.tbx_author = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_assunto = new System.Windows.Forms.Label();
            this.lbl_data_criacao = new System.Windows.Forms.Label();
            this.lbl_creator = new System.Windows.Forms.Label();
            this.lbl_author = new System.Windows.Forms.Label();
            this.pan_down = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.pan_completo.SuspendLayout();
            this.pan_tot.SuspendLayout();
            this.gpb_grupo_cadastro.SuspendLayout();
            this.pan_down.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_completo
            // 
            this.pan_completo.Controls.Add(this.pan_tot);
            this.pan_completo.Controls.Add(this.pan_down);
            this.pan_completo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_completo.Location = new System.Drawing.Point(0, 0);
            this.pan_completo.Name = "pan_completo";
            this.pan_completo.Size = new System.Drawing.Size(309, 304);
            this.pan_completo.TabIndex = 0;
            // 
            // pan_tot
            // 
            this.pan_tot.Controls.Add(this.gpb_grupo_cadastro);
            this.pan_tot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tot.Location = new System.Drawing.Point(0, 0);
            this.pan_tot.Name = "pan_tot";
            this.pan_tot.Size = new System.Drawing.Size(309, 259);
            this.pan_tot.TabIndex = 2;
            // 
            // gpb_grupo_cadastro
            // 
            this.gpb_grupo_cadastro.Controls.Add(this.dtp_data_alteracao);
            this.gpb_grupo_cadastro.Controls.Add(this.dtp_data_criacao);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_log);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_keywords);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_titulo);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_subject);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_creator);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_data_alteracao);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_log);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_keywords);
            this.gpb_grupo_cadastro.Controls.Add(this.tbx_author);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_title);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_assunto);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_data_criacao);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_creator);
            this.gpb_grupo_cadastro.Controls.Add(this.lbl_author);
            this.gpb_grupo_cadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_grupo_cadastro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.gpb_grupo_cadastro.Location = new System.Drawing.Point(0, 0);
            this.gpb_grupo_cadastro.Name = "gpb_grupo_cadastro";
            this.gpb_grupo_cadastro.Size = new System.Drawing.Size(309, 259);
            this.gpb_grupo_cadastro.TabIndex = 0;
            this.gpb_grupo_cadastro.TabStop = false;
            this.gpb_grupo_cadastro.Text = "Informações do pdf";
            // 
            // dtp_data_alteracao
            // 
            this.dtp_data_alteracao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_data_alteracao.Location = new System.Drawing.Point(128, 114);
            this.dtp_data_alteracao.Name = "dtp_data_alteracao";
            this.dtp_data_alteracao.Size = new System.Drawing.Size(169, 23);
            this.dtp_data_alteracao.TabIndex = 4;
            // 
            // dtp_data_criacao
            // 
            this.dtp_data_criacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_data_criacao.Location = new System.Drawing.Point(119, 53);
            this.dtp_data_criacao.Name = "dtp_data_criacao";
            this.dtp_data_criacao.Size = new System.Drawing.Size(178, 23);
            this.dtp_data_criacao.TabIndex = 2;
            // 
            // tbx_log
            // 
            this.tbx_log.Location = new System.Drawing.Point(119, 232);
            this.tbx_log.MaxLength = 100;
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.Size = new System.Drawing.Size(178, 23);
            this.tbx_log.TabIndex = 8;
            // 
            // tbx_keywords
            // 
            this.tbx_keywords.Location = new System.Drawing.Point(65, 204);
            this.tbx_keywords.MaxLength = 100;
            this.tbx_keywords.Name = "tbx_keywords";
            this.tbx_keywords.Size = new System.Drawing.Size(232, 23);
            this.tbx_keywords.TabIndex = 7;
            // 
            // tbx_titulo
            // 
            this.tbx_titulo.Location = new System.Drawing.Point(65, 175);
            this.tbx_titulo.MaxLength = 100;
            this.tbx_titulo.Name = "tbx_titulo";
            this.tbx_titulo.Size = new System.Drawing.Size(232, 23);
            this.tbx_titulo.TabIndex = 6;
            // 
            // tbx_subject
            // 
            this.tbx_subject.Location = new System.Drawing.Point(78, 143);
            this.tbx_subject.MaxLength = 100;
            this.tbx_subject.Name = "tbx_subject";
            this.tbx_subject.Size = new System.Drawing.Size(219, 23);
            this.tbx_subject.TabIndex = 5;
            // 
            // tbx_creator
            // 
            this.tbx_creator.Location = new System.Drawing.Point(119, 85);
            this.tbx_creator.MaxLength = 100;
            this.tbx_creator.Name = "tbx_creator";
            this.tbx_creator.Size = new System.Drawing.Size(178, 23);
            this.tbx_creator.TabIndex = 3;
            // 
            // lbl_data_alteracao
            // 
            this.lbl_data_alteracao.AutoSize = true;
            this.lbl_data_alteracao.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_data_alteracao.Location = new System.Drawing.Point(15, 118);
            this.lbl_data_alteracao.Name = "lbl_data_alteracao";
            this.lbl_data_alteracao.Size = new System.Drawing.Size(107, 16);
            this.lbl_data_alteracao.TabIndex = 0;
            this.lbl_data_alteracao.Text = "Data de alteração:";
            // 
            // lbl_log
            // 
            this.lbl_log.AutoSize = true;
            this.lbl_log.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_log.Location = new System.Drawing.Point(15, 234);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(99, 16);
            this.lbl_log.TabIndex = 0;
            this.lbl_log.Text = "Diretório de log:";
            // 
            // lbl_keywords
            // 
            this.lbl_keywords.AutoSize = true;
            this.lbl_keywords.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_keywords.Location = new System.Drawing.Point(15, 205);
            this.lbl_keywords.Name = "lbl_keywords";
            this.lbl_keywords.Size = new System.Drawing.Size(46, 16);
            this.lbl_keywords.TabIndex = 0;
            this.lbl_keywords.Text = "Chave:";
            // 
            // tbx_author
            // 
            this.tbx_author.Location = new System.Drawing.Point(65, 23);
            this.tbx_author.MaxLength = 100;
            this.tbx_author.Name = "tbx_author";
            this.tbx_author.Size = new System.Drawing.Size(232, 23);
            this.tbx_author.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_title.Location = new System.Drawing.Point(15, 176);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(45, 16);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Título:";
            // 
            // lbl_assunto
            // 
            this.lbl_assunto.AutoSize = true;
            this.lbl_assunto.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_assunto.Location = new System.Drawing.Point(15, 144);
            this.lbl_assunto.Name = "lbl_assunto";
            this.lbl_assunto.Size = new System.Drawing.Size(57, 16);
            this.lbl_assunto.TabIndex = 0;
            this.lbl_assunto.Text = "Assunto:";
            // 
            // lbl_data_criacao
            // 
            this.lbl_data_criacao.AutoSize = true;
            this.lbl_data_criacao.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_data_criacao.Location = new System.Drawing.Point(15, 57);
            this.lbl_data_criacao.Name = "lbl_data_criacao";
            this.lbl_data_criacao.Size = new System.Drawing.Size(98, 16);
            this.lbl_data_criacao.TabIndex = 0;
            this.lbl_data_criacao.Text = "Data de criação:";
            // 
            // lbl_creator
            // 
            this.lbl_creator.AutoSize = true;
            this.lbl_creator.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_creator.Location = new System.Drawing.Point(15, 86);
            this.lbl_creator.Name = "lbl_creator";
            this.lbl_creator.Size = new System.Drawing.Size(100, 16);
            this.lbl_creator.TabIndex = 0;
            this.lbl_creator.Text = "Aplicativo autor:";
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbl_author.Location = new System.Drawing.Point(15, 24);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(43, 16);
            this.lbl_author.TabIndex = 0;
            this.lbl_author.Text = "Autor:";
            // 
            // pan_down
            // 
            this.pan_down.Controls.Add(this.btn_edit);
            this.pan_down.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_down.Location = new System.Drawing.Point(0, 259);
            this.pan_down.Name = "pan_down";
            this.pan_down.Size = new System.Drawing.Size(309, 45);
            this.pan_down.TabIndex = 1;
            // 
            // btn_edit
            // 
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_edit.Location = new System.Drawing.Point(233, 3);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(71, 36);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "Editar";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // FO_FormularioConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(309, 304);
            this.Controls.Add(this.pan_completo);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_FormularioConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.pan_completo.ResumeLayout(false);
            this.pan_tot.ResumeLayout(false);
            this.gpb_grupo_cadastro.ResumeLayout(false);
            this.gpb_grupo_cadastro.PerformLayout();
            this.pan_down.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_completo;
        private System.Windows.Forms.Panel pan_tot;
        private System.Windows.Forms.GroupBox gpb_grupo_cadastro;
        private System.Windows.Forms.Panel pan_down;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.DateTimePicker dtp_data_criacao;
        private System.Windows.Forms.TextBox tbx_creator;
        private System.Windows.Forms.TextBox tbx_author;
        private System.Windows.Forms.Label lbl_data_criacao;
        private System.Windows.Forms.Label lbl_creator;
        private System.Windows.Forms.DateTimePicker dtp_data_alteracao;
        private System.Windows.Forms.TextBox tbx_keywords;
        private System.Windows.Forms.TextBox tbx_titulo;
        private System.Windows.Forms.TextBox tbx_subject;
        private System.Windows.Forms.Label lbl_data_alteracao;
        private System.Windows.Forms.Label lbl_keywords;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_assunto;
        private System.Windows.Forms.TextBox tbx_log;
        private System.Windows.Forms.Label lbl_log;
    }
}