namespace CaseMaker.Visão
{
    partial class FO_CadastroStatus
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
            this.pan_form = new System.Windows.Forms.Panel();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.btn_cancela = new System.Windows.Forms.Button();
            this.gpb_formulario = new System.Windows.Forms.GroupBox();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.tbx_nome = new System.Windows.Forms.TextBox();
            this.ckb_erro = new System.Windows.Forms.CheckBox();
            this.pan_botton.SuspendLayout();
            this.pan_form.SuspendLayout();
            this.gpb_formulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_botton
            // 
            this.pan_botton.Controls.Add(this.btn_cancela);
            this.pan_botton.Controls.Add(this.btn_confirmar);
            this.pan_botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_botton.Location = new System.Drawing.Point(0, 123);
            this.pan_botton.Name = "pan_botton";
            this.pan_botton.Size = new System.Drawing.Size(324, 39);
            this.pan_botton.TabIndex = 0;
            // 
            // pan_form
            // 
            this.pan_form.Controls.Add(this.gpb_formulario);
            this.pan_form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_form.Location = new System.Drawing.Point(0, 0);
            this.pan_form.Name = "pan_form";
            this.pan_form.Size = new System.Drawing.Size(324, 123);
            this.pan_form.TabIndex = 1;
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_confirmar.Location = new System.Drawing.Point(246, 7);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(75, 29);
            this.btn_confirmar.TabIndex = 18;
            this.btn_confirmar.Text = "Cadastrar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // btn_cancela
            // 
            this.btn_cancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancela.Location = new System.Drawing.Point(174, 7);
            this.btn_cancela.Name = "btn_cancela";
            this.btn_cancela.Size = new System.Drawing.Size(66, 29);
            this.btn_cancela.TabIndex = 18;
            this.btn_cancela.Text = "Cancelar";
            this.btn_cancela.UseVisualStyleBackColor = true;
            this.btn_cancela.Click += new System.EventHandler(this.btn_cancela_Click);
            // 
            // gpb_formulario
            // 
            this.gpb_formulario.Controls.Add(this.ckb_erro);
            this.gpb_formulario.Controls.Add(this.tbx_nome);
            this.gpb_formulario.Controls.Add(this.lbl_nome);
            this.gpb_formulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_formulario.Location = new System.Drawing.Point(0, 0);
            this.gpb_formulario.Name = "gpb_formulario";
            this.gpb_formulario.Size = new System.Drawing.Size(324, 123);
            this.gpb_formulario.TabIndex = 0;
            this.gpb_formulario.TabStop = false;
            this.gpb_formulario.Text = "Cadastro de Status";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Location = new System.Drawing.Point(13, 23);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(42, 16);
            this.lbl_nome.TabIndex = 0;
            this.lbl_nome.Text = "Nome";
            // 
            // tbx_nome
            // 
            this.tbx_nome.Location = new System.Drawing.Point(62, 23);
            this.tbx_nome.MaxLength = 50;
            this.tbx_nome.Name = "tbx_nome";
            this.tbx_nome.Size = new System.Drawing.Size(250, 23);
            this.tbx_nome.TabIndex = 1;
            // 
            // ckb_erro
            // 
            this.ckb_erro.AutoSize = true;
            this.ckb_erro.Location = new System.Drawing.Point(204, 52);
            this.ckb_erro.Name = "ckb_erro";
            this.ckb_erro.Size = new System.Drawing.Size(108, 20);
            this.ckb_erro.TabIndex = 2;
            this.ckb_erro.Text = "Status de Erro";
            this.ckb_erro.UseVisualStyleBackColor = true;
            // 
            // FO_CadastroStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(324, 162);
            this.Controls.Add(this.pan_form);
            this.Controls.Add(this.pan_botton);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_CadastroStatus";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.pan_botton.ResumeLayout(false);
            this.pan_form.ResumeLayout(false);
            this.gpb_formulario.ResumeLayout(false);
            this.gpb_formulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_botton;
        private System.Windows.Forms.Panel pan_form;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.Button btn_cancela;
        private System.Windows.Forms.GroupBox gpb_formulario;
        private System.Windows.Forms.TextBox tbx_nome;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.CheckBox ckb_erro;
    }
}