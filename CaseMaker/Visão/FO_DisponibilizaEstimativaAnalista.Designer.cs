namespace CaseMaker.Visão
{
    partial class FO_DisponibilizaEstimativaAnalista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FO_DisponibilizaEstimativaAnalista));
            this.pan_superior = new System.Windows.Forms.Panel();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.tbx_estimativa = new System.Windows.Forms.TextBox();
            this.btn_copiar = new System.Windows.Forms.Button();
            this.pan_superior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_superior
            // 
            this.pan_superior.Controls.Add(this.btn_copiar);
            this.pan_superior.Controls.Add(this.tbx_estimativa);
            this.pan_superior.Controls.Add(this.lbl_titulo);
            this.pan_superior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_superior.Location = new System.Drawing.Point(0, 0);
            this.pan_superior.Name = "pan_superior";
            this.pan_superior.Size = new System.Drawing.Size(459, 344);
            this.pan_superior.TabIndex = 0;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Location = new System.Drawing.Point(13, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(58, 16);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Relatório";
            // 
            // tbx_estimativa
            // 
            this.tbx_estimativa.AcceptsTab = true;
            this.tbx_estimativa.AllowDrop = true;
            this.tbx_estimativa.Location = new System.Drawing.Point(16, 33);
            this.tbx_estimativa.MaxLength = 5000;
            this.tbx_estimativa.Multiline = true;
            this.tbx_estimativa.Name = "tbx_estimativa";
            this.tbx_estimativa.Size = new System.Drawing.Size(431, 281);
            this.tbx_estimativa.TabIndex = 1;
            // 
            // btn_copiar
            // 
            this.btn_copiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_copiar.Location = new System.Drawing.Point(402, 317);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(54, 25);
            this.btn_copiar.TabIndex = 1;
            this.btn_copiar.Text = "Copiar";
            this.btn_copiar.UseVisualStyleBackColor = true;
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click);
            // 
            // FO_DisponibilizaEstimativaAnalista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(459, 344);
            this.Controls.Add(this.pan_superior);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FO_DisponibilizaEstimativaAnalista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimativa de Testes";
            this.pan_superior.ResumeLayout(false);
            this.pan_superior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_superior;
        private System.Windows.Forms.TextBox tbx_estimativa;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Button btn_copiar;
    }
}