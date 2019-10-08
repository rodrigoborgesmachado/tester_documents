using CaseMaker.Model;
using CaseMaker.Visão;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CaseMaker.Util.Enumerator;
using static CaseMaker.Util.Global;

namespace CaseMaker
{
    public partial class FO_Principal : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Controle de eventos da tela
        /// </summary>
        bool lockchange = false;

        List<TabPage> pages = new List<TabPage>();
        /// <summary>
        /// Páginas abertas
        /// </summary>
        public List<TabPage> Pages
        {
            get
            {
                return pages;
            }
            set
            {
                this.pages = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado no clique de novo projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_novo_projeto_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.btn_novo_projeto_Click()", Util.Global.TipoLog.DETALHADO);
            AbrirJanelaDeCadastro(Util.DataBase.GetIncrement("MAKDOCUMENTS"), 0, Util.Enumerator.Tarefa.INCLUINDO);
        }

        /// <summary>
        /// CArrega informações após seleção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv_projetos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.trv_projetos_AfterSelect()", Util.Global.TipoLog.DETALHADO);
            string codigo = (string)trv_projetos.SelectedNode.Tag;

            AbrePagina(codigo);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_editar_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_editar_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString().Split(':')[0];
            string tarefa = item.Tag.ToString().Split(':')[1];
            AbrirJanelaDeCadastro(int.Parse(codigo), int.Parse(tarefa), Util.Enumerator.Tarefa.EDITANDO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_excluir_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_excluir_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];
            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            if(MessageBox.Show("Deseja excluir o projeto: " + project.Nome + "?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (project.Delete())
                    MessageBox.Show("Excluído com sucesso!");
                else
                    MessageBox.Show("Erro ao excluir!");
                CarregaTreeView();
                FecharTela(Telas.CADASTRO_PROJETO);
                FecharTela(Telas.CADASTRO_ESTIMATIVA);
                FecharTela(Telas.CADASTRO_CENARIO);
                FecharTela(Telas.CADASTRO_PROJETO_INCLUIR);
            }
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_estimativa_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_estimativa_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));

            UC_CadastroEstimativa estimativa = new UC_CadastroEstimativa(this, project.GetEstimativa(), Tarefa.EDITANDO, Telas.CADASTRO_ESTIMATIVA);
            AbreJanela(estimativa, "Estimativa - " + project.Nome, Telas.CADASTRO_ESTIMATIVA);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_caso_uso_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_caso_uso_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            MD_Cenario cen = new MD_Cenario(Util.DataBase.GetIncrement("MAKCENARIOS"), project);

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, project, cen, Tarefa.INCLUINDO, Telas.CADASTRO_CENARIO, TipoSistema.GENERICO);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_caso_usomodeloSSI_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_caso_uso_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            MD_Cenario cen = new MD_Cenario(Util.DataBase.GetIncrement("MAKCENARIOS"), project);

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, project, cen, Tarefa.INCLUINDO, Telas.CADASTRO_CENARIO, TipoSistema.SSI);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_caso_usomodeloSSM_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_caso_uso_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            MD_Cenario cen = new MD_Cenario(Util.DataBase.GetIncrement("MAKCENARIOS"), project);

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, project, cen, Tarefa.INCLUINDO, Telas.CADASTRO_CENARIO, TipoSistema.SSM);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_caso_usomodeloSSU_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_caso_uso_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            MD_Cenario cen = new MD_Cenario(Util.DataBase.GetIncrement("MAKCENARIOS"), project);

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, project, cen, Tarefa.INCLUINDO, Telas.CADASTRO_CENARIO, TipoSistema.SSU);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluir_caso_usomodeloLdxMail_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluir_caso_uso_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            string codigo = item.Tag.ToString().Split(':')[0];
            string numerotarefa = item.Tag.ToString().Split(':')[1];

            MD_Project project = new MD_Project(int.Parse(codigo), int.Parse(numerotarefa));
            MD_Cenario cen = new MD_Cenario(Util.DataBase.GetIncrement("MAKCENARIOS"), project);

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, project, cen, Tarefa.INCLUINDO, Telas.CADASTRO_CENARIO, TipoSistema.SSU);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_editar_cenario_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_editar_cenario_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            MD_Cenario cen = (MD_Cenario)item.Tag;

            UC_CadastroCenarios cenario = new UC_CadastroCenarios(this, cen.Project, cen, Tarefa.EDITANDO, Telas.CADASTRO_CENARIO, TipoSistema.GENERICO);
            AbreJanela(cenario, "Cenário " + cen.Codigo, Telas.CADASTRO_CENARIO);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_excluir_cenario_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_excluir_cenario_selected_Click()", Util.Global.TipoLog.DETALHADO);
            MenuItem item = (MenuItem)sender;

            MD_Cenario cen = (MD_Cenario)item.Tag;
            if (MessageBox.Show("Deseja excluir o cenário " + cen.Codigo + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (cen.Delete())
                {
                    MessageBox.Show("Excluído com sucesso!");
                    CarregaTreeView();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir o cenário + " + cen.Codigo + "!");
                }
            }
        }

        /// <summary>
        /// Evento lançado quando a opção de log é alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_log_simples_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange)
                return;
            lockchange = true;

            tsp_log_simples.Checked = true;
            tsp_log_detalhado.Checked = !tsp_log_simples.Checked;
            Util.DataBase.SetLog(TipoLog.SIMPLES);
            Util.Global.log_system = Util.DataBase.GetLog();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando a opção de log é alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_log_detalhado_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange)
                return;
            lockchange = true;

            tsp_log_detalhado.Checked = true;
            tsp_log_simples.Checked = !tsp_log_detalhado.Checked;
            Util.DataBase.SetLog(TipoLog.DETALHADO);
            Util.Global.log_system = Util.DataBase.GetLog();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado no clique da opção de gerar backup nas opções
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_gerar_backup_Click(object sender, EventArgs e)
        {
            if (lockchange)
                return;
            lockchange = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecione onde o árquivo de backup será salvo!";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                bool retorno = true;
                FO_Agurade agurade = new FO_Agurade("Gerando Backup");
                agurade.Show();

                string saida = dialog.SelectedPath.ToString();
                string mensagemErro = "";
                retorno = Util.Backup.GerarBackup(saida, ref mensagemErro);

                File.Copy(Util.Global.nome_arquivo_backup, saida + "\\backup_file.bkp");

                agurade.Dispose();
                if (retorno)
                    MessageBox.Show("Backup gerado com sucesso e está disponível na pasta: " + saida + "\\backup_file.bkp!");
                else
                    MessageBox.Show("Erro ao gerar backup!");
            }

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado no clique da opção de buscar backup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_buscar_backup_Click(object sender, EventArgs e)
        {
            if (lockchange)
                return;
            lockchange = true;

            OpenFileDialog dialog_f = new OpenFileDialog();

            if (dialog_f.ShowDialog() == DialogResult.OK)
            {
                bool retorno = true;
                FO_Agurade agurade = new FO_Agurade("Gerando Backup");
                agurade.Show();

                string saida = dialog_f.FileName.ToString();
                string mensagemErro = "";
                retorno = Util.Backup.BuscarBackup(saida, ref mensagemErro);

                agurade.Dispose();
                if (retorno)
                    MessageBox.Show("Backup importado com sucesso e está disponível na pasta: " + saida + "\\backup_file.bkp!");
                else
                    MessageBox.Show("Erro ao importar backup!");
                CarregaTreeView();
            }

            lockchange = false;
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        public FO_Principal()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.FO_Principal()", Util.Global.TipoLog.DETALHADO);
            IniciaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz a inicialização do Form
        /// </summary>
        public void IniciaForm()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.IniciaForm()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            CarregaTreeView();
            CarregaMenuOpcoes();
        }

        /// <summary>
        /// Método que carrega o menu de opções
        /// </summary>
        public void CarregaMenuOpcoes()
        {
            lockchange = true;

            tsp_log_simples.Click += Tsp_log_simples_CheckedChanged;
            tsp_log_detalhado.Click += Tsp_log_detalhado_CheckedChanged;

            tsp_log_detalhado.Checked = Util.Global.log_system == Util.Global.TipoLog.DETALHADO;
            tsp_log_simples.Checked = !tsp_log_detalhado.Checked;

            tsp_gerar_backup.Click += Tsp_gerar_backup_Click;
            tsp_buscar_backup.Click += Tsp_buscar_backup_Click;

            lockchange = false;
        }

        /// <summary>
        /// Método que carrega o tree view
        /// </summary>
        public void CarregaTreeView()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.CarregaTreeView()", Util.Global.TipoLog.DETALHADO);
            this.trv_projetos.ExpandAll();
            this.trv_projetos.Nodes.Clear();
            this.trv_projetos.Scrollable = true;

            SQLiteDataReader reader = new MD_Project(0, 0).RetornaTodosProjetos();
            while (reader.Read())
            {
                MD_Project project = new MD_Project(int.Parse(reader["CODIGOPROJ"].ToString()), int.Parse(reader["TAREFA"].ToString()));

                TreeNode node = new TreeNode(project.NumeroTarefa + " - " + project.Nome);
                node.Tag = "projeto:" +project.Codigo+ ":" + project.NumeroTarefa;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;

                MenuItem item_editar = new MenuItem("Editar", item_editar_selected_Click);
                item_editar.Tag = project.Codigo + ":" + project.NumeroTarefa;
                MenuItem item_excluir = new MenuItem("Excluir", item_excluir_selected_Click);
                item_excluir.Tag = project.Codigo + ":" + project.NumeroTarefa;
                MenuItem item_incluir_estimativa = new MenuItem("Editar Estimativa", item_incluir_estimativa_selected_Click);
                item_incluir_estimativa.Tag = project.Codigo + ":" + project.NumeroTarefa;
                MenuItem item_incluir_cenario = new MenuItem("Adicionar Cenário", item_incluir_caso_uso_selected_Click);
                item_incluir_cenario.Tag = project.Codigo + ":" + project.NumeroTarefa;

                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add(item_editar);
                menu.MenuItems.Add(item_excluir);
                menu.MenuItems.Add(item_incluir_estimativa);
                menu.MenuItems.Add(item_incluir_cenario);
                node.ContextMenu = menu;

                AdicionarEstimativas(project, ref node);

                AdicionaCenarios(project, ref node);

                trv_projetos.Nodes.Add(node);
            }
            reader.Close();
            trv_projetos.ExpandAll();
        }

        /// <summary>
        /// Método que adiciona a estimativa no node do projeto
        /// </summary>
        /// <param name="project">Projeto selecionado no node</param>
        /// /// <param name="node">Node a acionar as estimativas</param>
        public void AdicionarEstimativas(MD_Project project, ref TreeNode node)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AdicionarEstimativas()", Util.Global.TipoLog.DETALHADO);
            MD_Estimativa estimativa = project.GetEstimativa();

            TreeNode nodeEstimativas = new TreeNode("Estimativa: " + Util.Document.CalculaTempoTotalEstimativa(estimativa));
            nodeEstimativas.Tag = "estimativa:" + estimativa.Codigo + ":" + project.Codigo + ":" + project.NumeroTarefa;
            nodeEstimativas.ImageIndex = 1;
            nodeEstimativas.SelectedImageIndex = 1;

            MenuItem item_editar_estimativa = new MenuItem("Editar", item_incluir_estimativa_selected_Click);
            item_editar_estimativa.Tag = project.Codigo + ":" + project.NumeroTarefa;

            ContextMenu menuEstimativa = new ContextMenu();
            menuEstimativa.MenuItems.Add(item_editar_estimativa);

            nodeEstimativas.ContextMenu = menuEstimativa;

            node.Nodes.Add(nodeEstimativas);
        }

        /// <summary>
        /// Método que adicionar os cenários de teste cadastrado para o projeto
        /// </summary>
        /// <param name="project">Projeto selecionado no node</param>
        /// /// <param name="node">Node a acionar os cenários</param>
        public void AdicionaCenarios(MD_Project project, ref TreeNode node)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AdicionaCenarios()", Util.Global.TipoLog.DETALHADO);
            MenuItem item_incluir_cenario = new MenuItem("Adicionar Cenário", item_incluir_caso_uso_selected_Click);
            MenuItem item_modelos_cenrios = new MenuItem("Modelos");
            MenuItem item_modelos_SSI = new MenuItem("SSI", item_incluir_caso_usomodeloSSI_selected_Click);
            item_modelos_cenrios.MenuItems.Add(item_modelos_SSI);

            item_incluir_cenario.Tag = project.Codigo + ":" + project.NumeroTarefa;
            item_modelos_SSI.Tag = project.Codigo + ":" + project.NumeroTarefa;

            TreeNode nodeCenarios = new TreeNode("Cenários");
            nodeCenarios.Tag = "tag:" + -1;
            nodeCenarios.ImageIndex = 2;
            nodeCenarios.SelectedImageIndex = 2;

            ContextMenu menuCenario = new ContextMenu();
            menuCenario.MenuItems.Add(item_incluir_cenario);
            menuCenario.MenuItems.Add(item_modelos_cenrios);
            nodeCenarios.ContextMenu = menuCenario;

            MenuItem item_editar_cenario = new MenuItem("Editar", item_editar_cenario_selected_Click);
            MenuItem item_excluir_cenario = new MenuItem("Excluir", item_excluir_cenario_selected_Click);
            
            

            SQLiteDataReader reader = new MD_Cenario(0, project).RetornaTodosCenarios();

            while (reader.Read())
            {
                MD_Cenario cenario = new MD_Cenario(int.Parse(reader["CODIGOCEN"].ToString()), project);

                TreeNode node_cen = new TreeNode("Cenario " + cenario.TipoDoSistema.ToString());
                node_cen.Tag = "cenario:" + cenario.Codigo + ":" + project.Codigo + ":" + project.NumeroTarefa;
                node_cen.ImageIndex = 3;
                node_cen.SelectedImageIndex = 3;
                item_editar_cenario.Tag = cenario;
                item_excluir_cenario.Tag = cenario;

                ContextMenu menuCen = new ContextMenu();
                menuCen.MenuItems.Add(item_editar_cenario);
                menuCen.MenuItems.Add(item_excluir_cenario);

                node_cen.ContextMenu = menuCen;

                nodeCenarios.Nodes.Add(node_cen);
            }
            reader.Close();
            node.Nodes.Add(nodeCenarios);
        }

        /// <summary>
        /// Método que abre a janela de cadastro de projeto
        /// </summary>
        public void AbrirJanelaDeCadastro(int codigo,int numtarefa, Util.Enumerator.Tarefa tarefa)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirJanelaDeCadastro()", Util.Global.TipoLog.DETALHADO);
            Telas tela = tarefa == Tarefa.INCLUINDO ? Telas.CADASTRO_PROJETO_INCLUIR : Telas.CADASTRO_PROJETO;
            AbreJanela(new Visão.UC_CadastroProjeto(this, codigo,numtarefa, tarefa, tela), "Cadastro - Projeto", tela);
        }

        /// <summary>
        /// Método que abre uma nova aba no tab page
        /// </summary>
        /// <param name="control">User control a ser aberto dentro da page</param>
        /// <param name="titulo">Título da aba da página a ser aberta</param>
        public void AbreJanela(UserControl control, string titulo, Telas tag)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbreJanela()", Util.Global.TipoLog.DETALHADO);
            int index = 0;
            Telas tag_aberto = Telas.CADASTRO_PROJETO;
            bool aberto = false;
            foreach(TabPage p in pages)
            {
                if ((int)p.Tag == (int)tag)
                {
                    tag_aberto = (Telas)p.Tag;
                    aberto = true;
                    break;
                }
                else index++;
            }

            if (aberto)
                FecharTela(tag_aberto);
            TabPage page = new TabPage(titulo);

            TabPage tabPage1 = new TabPage(titulo);
            tabPage1.Tag = (int)tag;
            pages.Add(tabPage1);

            tabPage1.Controls.Add(control);
            this.tbc_table_control.Controls.Add(tabPage1);
            this.tbc_table_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_table_control.Name = titulo;

            index = 0;
            foreach(TabPage p in this.tbc_table_control.Controls)
            {
                if ((int)p.Tag == (int)tag)
                    break;
                index++;
            }

            this.tbc_table_control.TabIndex = index;
            this.tbc_table_control.SelectedIndex = index;
        }

        /// <summary>
        /// Método que fecha a tela
        /// </summary>
        /// <param name="tag"></param>
        public void FecharTela(Telas tag)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.FecharTela()", Util.Global.TipoLog.DETALHADO);
            int index = 0;
            foreach (TabPage p in pages)
            {
                if ((int)p.Tag == (int)tag)
                {
                    p.Dispose();
                    break;
                }
                else index++;
            }
            
            if(index < pages.Count)
                pages.RemoveAt(index);
        }

        /// <summary>
        /// Método que abre a página selecionada no treeview
        /// </summary>
        /// <param name=""></param>
        public void AbrePagina(string code)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrePagina()", Util.Global.TipoLog.DETALHADO);
            int codigo = 0;
            string _base = code.Split(':')[0];
            if (_base.Equals("tag"))
            {
                return;
            }
            else if (_base.Equals("projeto"))
            {
                codigo = int.Parse(code.Split(':')[1]);
                AbrirJanelaDeCadastro(codigo, int.Parse(code.Split(':')[2]), Util.Enumerator.Tarefa.VISUALIZANDO);
            }
            else if (_base.Equals("estimativa"))
            {
                codigo = int.Parse(code.Split(':')[1]);
                MD_Project project = new MD_Project(int.Parse(code.Split(':')[2]), int.Parse(code.Split(':')[3]));

                UC_CadastroEstimativa estimativa = new UC_CadastroEstimativa(this, new MD_Estimativa(codigo, project), Tarefa.VISUALIZANDO, Telas.CADASTRO_ESTIMATIVA);
                AbreJanela(estimativa, "Estimativa - " + project.Nome, Telas.CADASTRO_ESTIMATIVA);
            }
            else if (_base.Equals("cenario"))
            {
                codigo = int.Parse(code.Split(':')[1]);

                MD_Project project = new MD_Project(int.Parse(code.Split(':')[2]), int.Parse(code.Split(':')[3]));
                MD_Cenario cenario = new MD_Cenario(codigo, project);

                 UC_CadastroCenarios estimativa = new UC_CadastroCenarios(this, cenario.Project, cenario, Tarefa.VISUALIZANDO, Telas.CADASTRO_ESTIMATIVA, TipoSistema.GENERICO);
                AbreJanela(estimativa, "Cenario " + cenario.Codigo, Telas.CADASTRO_CENARIO);
            }
        }

        #endregion Métodos

    }
}
