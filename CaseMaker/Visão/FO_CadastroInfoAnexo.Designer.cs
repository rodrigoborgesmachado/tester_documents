namespace CaseMaker.Visão
{
    partial class FO_CadastroInfoAnexo
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
            this.pan_botton = new System.Windows.Forms.Panel();
            this.btn_cancela = new System.Windows.Forms.Button();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.pan_formulario = new System.Windows.Forms.Panel();
            this.btn_arquivo = new System.Windows.Forms.Button();
            this.tbx_descricao = new System.Windows.Forms.TextBox();
            this.lbl_descricao = new System.Windows.Forms.Label();
            this.tbx_file = new System.Windows.Forms.TextBox();
            this.lbl_arquivo = new System.Windows.Forms.Label();
            this.pan_botton.SuspendLayout();
            this.pan_formulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_botton
            // 
            this.pan_botton.Controls.Add(this.btn_cancela);
            this.pan_botton.Controls.Add(this.btn_confirmar);
            this.pan_botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_botton.Location = new System.Drawing.Point(0, 229);
            this.pan_botton.Name = "pan_botton";
            this.pan_botton.Size = new System.Drawing.Size(343, 39);
            this.pan_botton.TabIndex = 1;
            // 
            // btn_cancela
            // 
            this.btn_cancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancela.Location = new System.Drawing.Point(193, 7);
            this.btn_cancela.Name = "btn_cancela";
            this.btn_cancela.Size = new System.Drawing.Size(66, 29);
            this.btn_cancela.TabIndex = 5;
            this.btn_cancela.Text = "Cancelar";
            this.btn_cancela.UseVisualStyleBackColor = true;
            this.btn_cancela.Click += new System.EventHandler(this.btn_cancela_Click);
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_confirmar.Location = new System.Drawing.Point(265, 7);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(75, 29);
            this.btn_confirmar.TabIndex = 4;
            this.btn_confirmar.Text = "Cadastrar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // pan_formulario
            // 
            this.pan_formulario.Controls.Add(this.btn_arquivo);
            this.pan_formulario.Controls.Add(this.tbx_descricao);
            this.pan_formulario.Controls.Add(this.lbl_descricao);
            this.pan_formulario.Controls.Add(this.tbx_file);
            this.pan_formulario.Controls.Add(this.lbl_arquivo);
            this.pan_formulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_formulario.Location = new System.Drawing.Point(0, 0);
            this.pan_formulario.Name = "pan_formulario";
            this.pan_formulario.Size = new System.Drawing.Size(343, 229);
            this.pan_formulario.TabIndex = 2;
            // 
            // btn_arquivo
            // 
            this.btn_arquivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_arquivo.Location = new System.Drawing.Point(302, 13);
            this.btn_arquivo.Name = "btn_arquivo";
            this.btn_arquivo.Size = new System.Drawing.Size(38, 23);
            this.btn_arquivo.TabIndex = 2;
            this.btn_arquivo.Text = "File";
            this.btn_arquivo.UseVisualStyleBackColor = true;
            this.btn_arquivo.Click += new System.EventHandler(this.btn_arquivo_Click);
            // 
            // tbx_descricao
            // 
            this.tbx_descricao.Location = new System.Drawing.Point(130, 42);
            this.tbx_descricao.MaxLength = 500;
            this.tbx_descricao.Multiline = true;
            this.tbx_descricao.Name = "tbx_descricao";
            this.tbx_descricao.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbx_descricao.Size = new System.Drawing.Size(210, 181);
            this.tbx_descricao.TabIndex = 3;
            // 
            // lbl_descricao
            // 
            this.lbl_descricao.AutoSize = true;
            this.lbl_descricao.Location = new System.Drawing.Point(13, 42);
            this.lbl_descricao.Name = "lbl_descricao";
            this.lbl_descricao.Size = new System.Drawing.Size(67, 16);
            this.lbl_descricao.TabIndex = 0;
            this.lbl_descricao.Text = "Descrição:";
            // 
            // tbx_file
            // 
            this.tbx_file.Enabled = false;
            this.tbx_file.Location = new System.Drawing.Point(130, 13);
            this.tbx_file.Name = "tbx_file";
            this.tbx_file.Size = new System.Drawing.Size(165, 23);
            this.tbx_file.TabIndex = 1;
            // 
            // lbl_arquivo
            // 
            this.lbl_arquivo.AutoSize = true;
            this.lbl_arquivo.Location = new System.Drawing.Point(13, 13);
            this.lbl_arquivo.Name = "lbl_arquivo";
            this.lbl_arquivo.Size = new System.Drawing.Size(110, 16);
            this.lbl_arquivo.TabIndex = 0;
            this.lbl_arquivo.Text = "Arquivo de anexo:";
            // 
            // FO_CadastroInfoAnexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(343, 268);
            this.Controls.Add(this.pan_formulario);
            this.Controls.Add(this.pan_botton);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_CadastroInfoAnexo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações do anexo";
            this.pan_botton.ResumeLayout(false);
            this.pan_formulario.ResumeLayout(false);
            this.pan_formulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_botton;
        private System.Windows.Forms.Button btn_cancela;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.Panel pan_formulario;
        private System.Windows.Forms.Label lbl_arquivo;
        private System.Windows.Forms.TextBox tbx_file;
        private System.Windows.Forms.Button btn_arquivo;
        private System.Windows.Forms.TextBox tbx_descricao;
        private System.Windows.Forms.Label lbl_descricao;
    }
}