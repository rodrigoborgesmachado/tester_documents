namespace CaseMaker.Visão
{
    partial class UC_CadastroCenarios
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CadastroCenarios));
            this.pan_botton = new System.Windows.Forms.Panel();
            this.btn_gerar_document = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.pan_tot = new System.Windows.Forms.Panel();
            this.pan_formularioGeral = new System.Windows.Forms.Panel();
            this.gpb_cadastroGeral = new System.Windows.Forms.GroupBox();
            this.lvw_anexos = new System.Windows.Forms.ListView();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.rbt_sql = new System.Windows.Forms.RadioButton();
            this.ckb_reparo = new System.Windows.Forms.CheckBox();
            this.rbt_oracle = new System.Windows.Forms.RadioButton();
            this.rbt_firebird = new System.Windows.Forms.RadioButton();
            this.btn_passos = new System.Windows.Forms.Button();
            this.btn_info_saida = new System.Windows.Forms.Button();
            this.btn_info_entrada = new System.Windows.Forms.Button();
            this.btn_removerAnexo = new System.Windows.Forms.Button();
            this.btn_adicionarAnexo = new System.Windows.Forms.Button();
            this.btn_add_status = new System.Windows.Forms.Button();
            this.btn_bancoUtilizado = new System.Windows.Forms.Button();
            this.btn_info_versãoSgbd = new System.Windows.Forms.Button();
            this.btn_info_tarefa = new System.Windows.Forms.Button();
            this.tbx_passos = new System.Windows.Forms.TextBox();
            this.lbl_passos = new System.Windows.Forms.Label();
            this.tbx_saida = new System.Windows.Forms.TextBox();
            this.lbl_saida = new System.Windows.Forms.Label();
            this.tbx_entrada = new System.Windows.Forms.TextBox();
            this.lbl_entrada = new System.Windows.Forms.Label();
            this.tbx_bancoUtilizado = new System.Windows.Forms.TextBox();
            this.lbl_bancoUtilizado = new System.Windows.Forms.Label();
            this.tbx_versaoSgbd = new System.Windows.Forms.TextBox();
            this.lbl_versaoSgbd = new System.Windows.Forms.Label();
            this.tbx_numero_tarefa = new System.Windows.Forms.TextBox();
            this.lbl_anexos = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_numeroTarefa = new System.Windows.Forms.Label();
            this.img_list = new System.Windows.Forms.ImageList(this.components);
            this.lbl_comboTipo = new System.Windows.Forms.Label();
            this.cmb_tipoSistema = new System.Windows.Forms.ComboBox();
            this.pan_botton.SuspendLayout();
            this.pan_tot.SuspendLayout();
            this.pan_formularioGeral.SuspendLayout();
            this.gpb_cadastroGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_botton
            // 
            this.pan_botton.Controls.Add(this.btn_gerar_document);
            this.pan_botton.Controls.Add(this.btn_excluir);
            this.pan_botton.Controls.Add(this.btn_confirmar);
            this.pan_botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_botton.Location = new System.Drawing.Point(0, 527);
            this.pan_botton.Name = "pan_botton";
            this.pan_botton.Size = new System.Drawing.Size(740, 35);
            this.pan_botton.TabIndex = 0;
            // 
            // btn_gerar_document
            // 
            this.btn_gerar_document.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gerar_document.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gerar_document.Location = new System.Drawing.Point(581, 3);
            this.btn_gerar_document.Name = "btn_gerar_document";
            this.btn_gerar_document.Size = new System.Drawing.Size(75, 29);
            this.btn_gerar_document.TabIndex = 24;
            this.btn_gerar_document.Text = "Gerar";
            this.btn_gerar_document.UseVisualStyleBackColor = true;
            this.btn_gerar_document.Click += new System.EventHandler(this.btn_gerar_document_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_excluir.Location = new System.Drawing.Point(500, 3);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 29);
            this.btn_excluir.TabIndex = 25;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_confirmar.Location = new System.Drawing.Point(662, 3);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(75, 29);
            this.btn_confirmar.TabIndex = 23;
            this.btn_confirmar.Text = "Cadastrar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // pan_tot
            // 
            this.pan_tot.AutoScroll = true;
            this.pan_tot.Controls.Add(this.pan_formularioGeral);
            this.pan_tot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tot.Location = new System.Drawing.Point(0, 0);
            this.pan_tot.Name = "pan_tot";
            this.pan_tot.Size = new System.Drawing.Size(740, 527);
            this.pan_tot.TabIndex = 1;
            // 
            // pan_formularioGeral
            // 
            this.pan_formularioGeral.AllowDrop = true;
            this.pan_formularioGeral.AutoScroll = true;
            this.pan_formularioGeral.Controls.Add(this.gpb_cadastroGeral);
            this.pan_formularioGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_formularioGeral.Location = new System.Drawing.Point(0, 0);
            this.pan_formularioGeral.Name = "pan_formularioGeral";
            this.pan_formularioGeral.Size = new System.Drawing.Size(740, 527);
            this.pan_formularioGeral.TabIndex = 0;
            // 
            // gpb_cadastroGeral
            // 
            this.gpb_cadastroGeral.Controls.Add(this.lbl_comboTipo);
            this.gpb_cadastroGeral.Controls.Add(this.lvw_anexos);
            this.gpb_cadastroGeral.Controls.Add(this.cmb_tipoSistema);
            this.gpb_cadastroGeral.Controls.Add(this.cmb_status);
            this.gpb_cadastroGeral.Controls.Add(this.rbt_sql);
            this.gpb_cadastroGeral.Controls.Add(this.ckb_reparo);
            this.gpb_cadastroGeral.Controls.Add(this.rbt_oracle);
            this.gpb_cadastroGeral.Controls.Add(this.rbt_firebird);
            this.gpb_cadastroGeral.Controls.Add(this.btn_passos);
            this.gpb_cadastroGeral.Controls.Add(this.btn_info_saida);
            this.gpb_cadastroGeral.Controls.Add(this.btn_info_entrada);
            this.gpb_cadastroGeral.Controls.Add(this.btn_removerAnexo);
            this.gpb_cadastroGeral.Controls.Add(this.btn_adicionarAnexo);
            this.gpb_cadastroGeral.Controls.Add(this.btn_add_status);
            this.gpb_cadastroGeral.Controls.Add(this.btn_bancoUtilizado);
            this.gpb_cadastroGeral.Controls.Add(this.btn_info_versãoSgbd);
            this.gpb_cadastroGeral.Controls.Add(this.btn_info_tarefa);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_passos);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_passos);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_saida);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_saida);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_entrada);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_entrada);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_bancoUtilizado);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_bancoUtilizado);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_versaoSgbd);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_versaoSgbd);
            this.gpb_cadastroGeral.Controls.Add(this.tbx_numero_tarefa);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_anexos);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_status);
            this.gpb_cadastroGeral.Controls.Add(this.lbl_numeroTarefa);
            this.gpb_cadastroGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_cadastroGeral.Location = new System.Drawing.Point(0, 0);
            this.gpb_cadastroGeral.Name = "gpb_cadastroGeral";
            this.gpb_cadastroGeral.Size = new System.Drawing.Size(740, 527);
            this.gpb_cadastroGeral.TabIndex = 0;
            this.gpb_cadastroGeral.TabStop = false;
            this.gpb_cadastroGeral.Text = "Cadastro de Cenário";
            // 
            // lvw_anexos
            // 
            this.lvw_anexos.Location = new System.Drawing.Point(366, 468);
            this.lvw_anexos.MultiSelect = false;
            this.lvw_anexos.Name = "lvw_anexos";
            this.lvw_anexos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvw_anexos.Size = new System.Drawing.Size(317, 56);
            this.lvw_anexos.TabIndex = 20;
            this.lvw_anexos.UseCompatibleStateImageBehavior = false;
            this.lvw_anexos.DoubleClick += new System.EventHandler(this.lvw_anexos_DoubleClick);
            // 
            // cmb_status
            // 
            this.cmb_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.ItemHeight = 15;
            this.cmb_status.Location = new System.Drawing.Point(96, 466);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(150, 23);
            this.cmb_status.TabIndex = 18;
            // 
            // rbt_sql
            // 
            this.rbt_sql.AllowDrop = true;
            this.rbt_sql.AutoSize = true;
            this.rbt_sql.Location = new System.Drawing.Point(617, 53);
            this.rbt_sql.Name = "rbt_sql";
            this.rbt_sql.Size = new System.Drawing.Size(92, 20);
            this.rbt_sql.TabIndex = 9;
            this.rbt_sql.Text = "SQL Server";
            this.rbt_sql.UseVisualStyleBackColor = true;
            // 
            // ckb_reparo
            // 
            this.ckb_reparo.AutoSize = true;
            this.ckb_reparo.Location = new System.Drawing.Point(642, 28);
            this.ckb_reparo.Name = "ckb_reparo";
            this.ckb_reparo.Size = new System.Drawing.Size(67, 20);
            this.ckb_reparo.TabIndex = 4;
            this.ckb_reparo.Text = "Reparo";
            this.ckb_reparo.UseVisualStyleBackColor = true;
            // 
            // rbt_oracle
            // 
            this.rbt_oracle.AllowDrop = true;
            this.rbt_oracle.AutoSize = true;
            this.rbt_oracle.Checked = true;
            this.rbt_oracle.Location = new System.Drawing.Point(479, 52);
            this.rbt_oracle.Name = "rbt_oracle";
            this.rbt_oracle.Size = new System.Drawing.Size(63, 20);
            this.rbt_oracle.TabIndex = 7;
            this.rbt_oracle.TabStop = true;
            this.rbt_oracle.Text = "Oracle";
            this.rbt_oracle.UseVisualStyleBackColor = true;
            // 
            // rbt_firebird
            // 
            this.rbt_firebird.AllowDrop = true;
            this.rbt_firebird.AutoSize = true;
            this.rbt_firebird.Location = new System.Drawing.Point(548, 53);
            this.rbt_firebird.Name = "rbt_firebird";
            this.rbt_firebird.Size = new System.Drawing.Size(70, 20);
            this.rbt_firebird.TabIndex = 8;
            this.rbt_firebird.Text = "Firebird";
            this.rbt_firebird.UseVisualStyleBackColor = true;
            // 
            // btn_passos
            // 
            this.btn_passos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_passos.BackgroundImage")));
            this.btn_passos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_passos.Location = new System.Drawing.Point(689, 347);
            this.btn_passos.Name = "btn_passos";
            this.btn_passos.Size = new System.Drawing.Size(20, 20);
            this.btn_passos.TabIndex = 17;
            this.btn_passos.UseVisualStyleBackColor = true;
            this.btn_passos.Click += new System.EventHandler(this.btn_passos_Click);
            // 
            // btn_info_saida
            // 
            this.btn_info_saida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_info_saida.BackgroundImage")));
            this.btn_info_saida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_info_saida.Location = new System.Drawing.Point(689, 229);
            this.btn_info_saida.Name = "btn_info_saida";
            this.btn_info_saida.Size = new System.Drawing.Size(20, 20);
            this.btn_info_saida.TabIndex = 15;
            this.btn_info_saida.UseVisualStyleBackColor = true;
            this.btn_info_saida.Click += new System.EventHandler(this.btn_info_saida_Click);
            // 
            // btn_info_entrada
            // 
            this.btn_info_entrada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_info_entrada.BackgroundImage")));
            this.btn_info_entrada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_info_entrada.Location = new System.Drawing.Point(689, 111);
            this.btn_info_entrada.Name = "btn_info_entrada";
            this.btn_info_entrada.Size = new System.Drawing.Size(20, 20);
            this.btn_info_entrada.TabIndex = 13;
            this.btn_info_entrada.UseVisualStyleBackColor = true;
            this.btn_info_entrada.Click += new System.EventHandler(this.btn_info_entrada_Click);
            // 
            // btn_removerAnexo
            // 
            this.btn_removerAnexo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_removerAnexo.BackgroundImage")));
            this.btn_removerAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_removerAnexo.Location = new System.Drawing.Point(689, 496);
            this.btn_removerAnexo.Name = "btn_removerAnexo";
            this.btn_removerAnexo.Size = new System.Drawing.Size(20, 20);
            this.btn_removerAnexo.TabIndex = 22;
            this.btn_removerAnexo.UseVisualStyleBackColor = true;
            this.btn_removerAnexo.Click += new System.EventHandler(this.btn_removerAnexo_Click);
            // 
            // btn_adicionarAnexo
            // 
            this.btn_adicionarAnexo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_adicionarAnexo.BackgroundImage")));
            this.btn_adicionarAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_adicionarAnexo.Location = new System.Drawing.Point(689, 470);
            this.btn_adicionarAnexo.Name = "btn_adicionarAnexo";
            this.btn_adicionarAnexo.Size = new System.Drawing.Size(20, 20);
            this.btn_adicionarAnexo.TabIndex = 21;
            this.btn_adicionarAnexo.UseVisualStyleBackColor = true;
            this.btn_adicionarAnexo.Click += new System.EventHandler(this.btn_adicionarAnexo_Click);
            // 
            // btn_add_status
            // 
            this.btn_add_status.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_status.BackgroundImage")));
            this.btn_add_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_status.Location = new System.Drawing.Point(252, 468);
            this.btn_add_status.Name = "btn_add_status";
            this.btn_add_status.Size = new System.Drawing.Size(20, 20);
            this.btn_add_status.TabIndex = 19;
            this.btn_add_status.UseVisualStyleBackColor = true;
            this.btn_add_status.Click += new System.EventHandler(this.btn_add_status_Click);
            // 
            // btn_bancoUtilizado
            // 
            this.btn_bancoUtilizado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_bancoUtilizado.BackgroundImage")));
            this.btn_bancoUtilizado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_bancoUtilizado.Location = new System.Drawing.Point(689, 82);
            this.btn_bancoUtilizado.Name = "btn_bancoUtilizado";
            this.btn_bancoUtilizado.Size = new System.Drawing.Size(20, 20);
            this.btn_bancoUtilizado.TabIndex = 11;
            this.btn_bancoUtilizado.UseVisualStyleBackColor = true;
            this.btn_bancoUtilizado.Click += new System.EventHandler(this.btn_bancoUtilizado_Click);
            // 
            // btn_info_versãoSgbd
            // 
            this.btn_info_versãoSgbd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_info_versãoSgbd.BackgroundImage")));
            this.btn_info_versãoSgbd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_info_versãoSgbd.Location = new System.Drawing.Point(259, 55);
            this.btn_info_versãoSgbd.Name = "btn_info_versãoSgbd";
            this.btn_info_versãoSgbd.Size = new System.Drawing.Size(20, 20);
            this.btn_info_versãoSgbd.TabIndex = 6;
            this.btn_info_versãoSgbd.UseVisualStyleBackColor = true;
            this.btn_info_versãoSgbd.Click += new System.EventHandler(this.btn_info_versãoSgbd_Click);
            // 
            // btn_info_tarefa
            // 
            this.btn_info_tarefa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_info_tarefa.BackgroundImage")));
            this.btn_info_tarefa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_info_tarefa.Location = new System.Drawing.Point(259, 26);
            this.btn_info_tarefa.Name = "btn_info_tarefa";
            this.btn_info_tarefa.Size = new System.Drawing.Size(20, 20);
            this.btn_info_tarefa.TabIndex = 2;
            this.btn_info_tarefa.UseVisualStyleBackColor = true;
            this.btn_info_tarefa.Click += new System.EventHandler(this.btn_info_tarefa_Click);
            // 
            // tbx_passos
            // 
            this.tbx_passos.AcceptsTab = true;
            this.tbx_passos.Location = new System.Drawing.Point(97, 348);
            this.tbx_passos.MaxLength = 30000;
            this.tbx_passos.Multiline = true;
            this.tbx_passos.Name = "tbx_passos";
            this.tbx_passos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_passos.Size = new System.Drawing.Size(586, 112);
            this.tbx_passos.TabIndex = 16;
            // 
            // lbl_passos
            // 
            this.lbl_passos.AutoSize = true;
            this.lbl_passos.Location = new System.Drawing.Point(6, 351);
            this.lbl_passos.Name = "lbl_passos";
            this.lbl_passos.Size = new System.Drawing.Size(47, 16);
            this.lbl_passos.TabIndex = 5;
            this.lbl_passos.Text = "Passos";
            // 
            // tbx_saida
            // 
            this.tbx_saida.AcceptsTab = true;
            this.tbx_saida.Location = new System.Drawing.Point(97, 230);
            this.tbx_saida.MaxLength = 30000;
            this.tbx_saida.Multiline = true;
            this.tbx_saida.Name = "tbx_saida";
            this.tbx_saida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_saida.Size = new System.Drawing.Size(586, 112);
            this.tbx_saida.TabIndex = 14;
            // 
            // lbl_saida
            // 
            this.lbl_saida.AutoSize = true;
            this.lbl_saida.Location = new System.Drawing.Point(6, 233);
            this.lbl_saida.Name = "lbl_saida";
            this.lbl_saida.Size = new System.Drawing.Size(39, 16);
            this.lbl_saida.TabIndex = 5;
            this.lbl_saida.Text = "Saída";
            // 
            // tbx_entrada
            // 
            this.tbx_entrada.AcceptsTab = true;
            this.tbx_entrada.Location = new System.Drawing.Point(97, 112);
            this.tbx_entrada.MaxLength = 30000;
            this.tbx_entrada.Multiline = true;
            this.tbx_entrada.Name = "tbx_entrada";
            this.tbx_entrada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_entrada.Size = new System.Drawing.Size(586, 112);
            this.tbx_entrada.TabIndex = 12;
            // 
            // lbl_entrada
            // 
            this.lbl_entrada.AutoSize = true;
            this.lbl_entrada.Location = new System.Drawing.Point(6, 115);
            this.lbl_entrada.Name = "lbl_entrada";
            this.lbl_entrada.Size = new System.Drawing.Size(51, 16);
            this.lbl_entrada.TabIndex = 5;
            this.lbl_entrada.Text = "Entrada";
            // 
            // tbx_bancoUtilizado
            // 
            this.tbx_bancoUtilizado.Location = new System.Drawing.Point(97, 83);
            this.tbx_bancoUtilizado.MaxLength = 50;
            this.tbx_bancoUtilizado.Name = "tbx_bancoUtilizado";
            this.tbx_bancoUtilizado.Size = new System.Drawing.Size(586, 23);
            this.tbx_bancoUtilizado.TabIndex = 10;
            // 
            // lbl_bancoUtilizado
            // 
            this.lbl_bancoUtilizado.AutoSize = true;
            this.lbl_bancoUtilizado.Location = new System.Drawing.Point(6, 86);
            this.lbl_bancoUtilizado.Name = "lbl_bancoUtilizado";
            this.lbl_bancoUtilizado.Size = new System.Drawing.Size(43, 16);
            this.lbl_bancoUtilizado.TabIndex = 5;
            this.lbl_bancoUtilizado.Text = "Banco";
            // 
            // tbx_versaoSgbd
            // 
            this.tbx_versaoSgbd.Location = new System.Drawing.Point(97, 54);
            this.tbx_versaoSgbd.MaxLength = 25;
            this.tbx_versaoSgbd.Name = "tbx_versaoSgbd";
            this.tbx_versaoSgbd.Size = new System.Drawing.Size(149, 23);
            this.tbx_versaoSgbd.TabIndex = 5;
            // 
            // lbl_versaoSgbd
            // 
            this.lbl_versaoSgbd.AutoSize = true;
            this.lbl_versaoSgbd.Location = new System.Drawing.Point(6, 57);
            this.lbl_versaoSgbd.Name = "lbl_versaoSgbd";
            this.lbl_versaoSgbd.Size = new System.Drawing.Size(84, 16);
            this.lbl_versaoSgbd.TabIndex = 5;
            this.lbl_versaoSgbd.Text = "Versão Banco";
            // 
            // tbx_numero_tarefa
            // 
            this.tbx_numero_tarefa.Location = new System.Drawing.Point(97, 25);
            this.tbx_numero_tarefa.MaxLength = 10;
            this.tbx_numero_tarefa.Name = "tbx_numero_tarefa";
            this.tbx_numero_tarefa.Size = new System.Drawing.Size(149, 23);
            this.tbx_numero_tarefa.TabIndex = 1;
            this.tbx_numero_tarefa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_numero_tarefa_KeyPress);
            // 
            // lbl_anexos
            // 
            this.lbl_anexos.AutoSize = true;
            this.lbl_anexos.Location = new System.Drawing.Point(310, 468);
            this.lbl_anexos.Name = "lbl_anexos";
            this.lbl_anexos.Size = new System.Drawing.Size(50, 16);
            this.lbl_anexos.TabIndex = 5;
            this.lbl_anexos.Text = "Anexos";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(6, 470);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(43, 16);
            this.lbl_status.TabIndex = 5;
            this.lbl_status.Text = "Status";
            // 
            // lbl_numeroTarefa
            // 
            this.lbl_numeroTarefa.AutoSize = true;
            this.lbl_numeroTarefa.Location = new System.Drawing.Point(6, 28);
            this.lbl_numeroTarefa.Name = "lbl_numeroTarefa";
            this.lbl_numeroTarefa.Size = new System.Drawing.Size(44, 16);
            this.lbl_numeroTarefa.TabIndex = 5;
            this.lbl_numeroTarefa.Text = "Tarefa";
            // 
            // img_list
            // 
            this.img_list.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_list.ImageStream")));
            this.img_list.TransparentColor = System.Drawing.Color.Transparent;
            this.img_list.Images.SetKeyName(0, "105-1051950_key-gpl-documents-guelph-library-project-transparent-documents20x20.p" +
        "ng");
            // 
            // lbl_comboTipo
            // 
            this.lbl_comboTipo.AutoSize = true;
            this.lbl_comboTipo.Location = new System.Drawing.Point(300, 28);
            this.lbl_comboTipo.Name = "lbl_comboTipo";
            this.lbl_comboTipo.Size = new System.Drawing.Size(100, 16);
            this.lbl_comboTipo.TabIndex = 20;
            this.lbl_comboTipo.Text = "Tipo do cenário:";
            // 
            // cmb_tipoSistema
            // 
            this.cmb_tipoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_tipoSistema.FormattingEnabled = true;
            this.cmb_tipoSistema.ItemHeight = 15;
            this.cmb_tipoSistema.Items.AddRange(new object[] {
            "SSI",
            "SSM",
            "SSU",
            "LdxMail"});
            this.cmb_tipoSistema.Location = new System.Drawing.Point(406, 28);
            this.cmb_tipoSistema.Name = "cmb_tipoSistema";
            this.cmb_tipoSistema.Size = new System.Drawing.Size(150, 23);
            this.cmb_tipoSistema.TabIndex = 3;
            // 
            // UC_CadastroCenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.pan_tot);
            this.Controls.Add(this.pan_botton);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Name = "UC_CadastroCenarios";
            this.Size = new System.Drawing.Size(740, 562);
            this.pan_botton.ResumeLayout(false);
            this.pan_tot.ResumeLayout(false);
            this.pan_formularioGeral.ResumeLayout(false);
            this.gpb_cadastroGeral.ResumeLayout(false);
            this.gpb_cadastroGeral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_botton;
        private System.Windows.Forms.Button btn_gerar_document;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.Panel pan_tot;
        private System.Windows.Forms.Panel pan_formularioGeral;
        private System.Windows.Forms.GroupBox gpb_cadastroGeral;
        private System.Windows.Forms.Button btn_info_tarefa;
        private System.Windows.Forms.TextBox tbx_numero_tarefa;
        private System.Windows.Forms.Label lbl_numeroTarefa;
        private System.Windows.Forms.CheckBox ckb_reparo;
        private System.Windows.Forms.Button btn_info_versãoSgbd;
        private System.Windows.Forms.TextBox tbx_versaoSgbd;
        private System.Windows.Forms.Label lbl_versaoSgbd;
        private System.Windows.Forms.RadioButton rbt_sql;
        private System.Windows.Forms.RadioButton rbt_firebird;
        private System.Windows.Forms.RadioButton rbt_oracle;
        private System.Windows.Forms.Button btn_bancoUtilizado;
        private System.Windows.Forms.TextBox tbx_bancoUtilizado;
        private System.Windows.Forms.Label lbl_bancoUtilizado;
        private System.Windows.Forms.Button btn_info_entrada;
        private System.Windows.Forms.TextBox tbx_entrada;
        private System.Windows.Forms.Label lbl_entrada;
        private System.Windows.Forms.Button btn_passos;
        private System.Windows.Forms.Button btn_info_saida;
        private System.Windows.Forms.TextBox tbx_passos;
        private System.Windows.Forms.Label lbl_passos;
        private System.Windows.Forms.TextBox tbx_saida;
        private System.Windows.Forms.Label lbl_saida;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Button btn_add_status;
        private System.Windows.Forms.ListView lvw_anexos;
        private System.Windows.Forms.Label lbl_anexos;
        private System.Windows.Forms.Button btn_removerAnexo;
        private System.Windows.Forms.Button btn_adicionarAnexo;
        private System.Windows.Forms.ImageList img_list;
        private System.Windows.Forms.Label lbl_comboTipo;
        private System.Windows.Forms.ComboBox cmb_tipoSistema;
    }
}
