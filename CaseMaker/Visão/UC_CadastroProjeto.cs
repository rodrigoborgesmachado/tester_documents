using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaseMaker.Model;
using static CaseMaker.Util.Enumerator;
using System.IO;

namespace CaseMaker.Visão
{
    public partial class UC_CadastroProjeto : UserControl
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Instância do projeto
        /// </summary>
        MD_Project project;

        /// <summary>
        /// Tarefa sendo efetuada na instância da tela
        /// </summary>
        Tarefa tarefa = Tarefa.VISUALIZANDO;

        /// <summary>
        /// Controle de eventos da tela
        /// </summary>
        bool lockchange = false;

        /// <summary>
        /// Controle da tela principal
        /// </summary>
        FO_Principal principal;

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo nome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_nome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nome do RRM a ser testado.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo descrição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_descricao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Descrição resumida do RRM a ser testado. Normalmente a primeira parte do RRM.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo analista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_analista_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Analista de negócios responsável pelo RRM a ser testado.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo programador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_programador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programador que desenvolveu o RRM a ser testado.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo tester
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_tester_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Analista de testes responsável pelo RRM.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo do RRM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_rrm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RRM a ser testado.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_tarefa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Número da tarefa do teste.");
        }

        /// <summary>
        /// Evento lançado no clique de botão de informações do campo versão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_versão_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Número da versão que o RRM será testado.");
        }

        /// <summary>
        /// Evento lançado quando o radio button de mudança é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_mudanca_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange) return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.lockchange()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;
            rbt_mudanca.Checked = !rbt_mudanca.Checked;
            rbt_correcao.Checked = !rbt_mudanca.Checked;
            lbl_rrm.Visible = tbx_rrm.Visible = btn_abrirFile.Visible = btn_selecionaRRM.Visible = btn_info_rrm.Visible = rbt_mudanca.Checked;
            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando o radio button de correção é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_correcao_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange) return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.rbt_correcao_CheckedChanged()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;
            rbt_correcao.Checked = !rbt_correcao.Checked;
            rbt_mudanca.Checked = !rbt_correcao.Checked;
            lbl_rrm.Visible = tbx_rrm.Visible = btn_abrirFile.Visible = btn_selecionaRRM.Visible = btn_info_rrm.Visible = rbt_mudanca.Checked;
            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando o radio button do SFV é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_sfv_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange) return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.rbt_sfv_CheckedChanged()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;
            rbt_sfv.Checked = !rbt_sfv.Checked;
            rbt_flex.Checked = !rbt_sfv.Checked;
            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando o radio button do flex é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_flex_CheckedChanged(object sender, EventArgs e)
        {
            if (lockchange) return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.rbt_flex_CheckedChanged()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;
            rbt_flex.Checked = !rbt_flex.Checked;
            rbt_sfv.Checked = !rbt_flex.Checked;
            lockchange = false;
        }

        /// <summary>
        /// Evento lançado no clique do botão 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selecionaRRM_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_selecionaRRM_Click()", Util.Global.TipoLog.DETALHADO);
            OpenDirectoryFile();
        }

        /// <summary>
        /// Evento lançado no clique do botão confirmar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_confirmar_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                tarefa = Tarefa.EDITANDO;
                CarregaBotoes();
                CarregaLabels();
                principal.CarregaTreeView();
            }
            else
                Incluir();
        }

        /// <summary>
        /// Evento lançado no clique do botão cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_cancelar_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                if (project.Delete())
                {
                    MessageBox.Show("Excluído com sucesso");
                }
                project = new MD_Project(project.Codigo, project.NumeroTarefa);
                FechaTela();
            }
            else
                Cancelar();
        }

        /// <summary>
        /// Evento disparado no clique do botão abrir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_abrirFile_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_abrirFile_Click()", Util.Global.TipoLog.DETALHADO);
            if (string.IsNullOrEmpty(tbx_rrm.Text))
            {
                MessageBox.Show("Selecione um arquivo!");
                return;
            }

            if (!File.Exists(tbx_rrm.Text))
            {
                MessageBox.Show("O arquivo não existe!");
                return;
            }

            string mensagem = "";
            if(!Util.Document.ExecutaFile(tbx_rrm.Text, false, ref mensagem))
            {
                MessageBox.Show(mensagem);
            }
        }

        /// <summary>
        /// Evento chamado quando o texto de número da tarefa é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_numero_tarefa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lockchange)
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de gerar relatório completo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_geraRelCompleto_Click(object sender, EventArgs e)
        {
            if (lockchange)
                return;
            Util.CL_Files.WriteOnTheLog("UC_CadastroProjeto.btn_geraRelCompleto_Click()", Util.Global.TipoLog.DETALHADO);
            GeraRelatorio(true);
        }

        /// <summary>
        /// Evento lançado no clique do botão de gerar relatório sem estimativa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_relSemEstimativa_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroProjeto.btn_relSemEstimativa_Click()", Util.Global.TipoLog.DETALHADO);
            GeraRelatorio(false);
        }

        #endregion Eventos

        #region Contrutores

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public UC_CadastroProjeto(FO_Principal principal, int codigo_projeto, int numtarefa, Tarefa tarefa, Telas tela)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.UC_CadastroProjeto()", Util.Global.TipoLog.DETALHADO);
            this.Tag = (int)tela;
            this.principal = principal;
            project = new MD_Project(codigo_projeto, numtarefa);
            this.tarefa = tarefa;
            IniciaUserControl();
        }

        #endregion Contrutores

        #region Métodos

        /// <summary>
        /// Método que inicializa tela
        /// </summary>
        public void IniciaUserControl()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.IniciaUserControl()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            CarregaLabels();
            CarregaBotoes();
        }

        /// <summary>
        /// Método que carrega os botões
        /// </summary>
        public void CarregaBotoes()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.CarregaBotoes()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.EDITANDO || tarefa == Tarefa.INCLUINDO)
            {
                btn_confirmar.Text = "Confirmar";
                btn_cancelar.Text = "Cancelar";
                btn_relSemEstimativa.Visible = btn_geraRelCompleto.Visible = false;
            }
            else if(tarefa == Tarefa.VISUALIZANDO)
            {
                btn_confirmar.Text = "Editar";
                btn_cancelar.Text = "Excluir";
                btn_relSemEstimativa.Visible = btn_geraRelCompleto.Visible = true;
            }
            lbl_rrm.Visible = tbx_rrm.Visible = btn_abrirFile.Visible = btn_selecionaRRM.Visible = btn_info_rrm.Visible = rbt_mudanca.Checked;
        }

        /// <summary>
        /// Método que carrega as informações da label
        /// </summary>
        public void CarregaLabels()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.CarregaLabels()", Util.Global.TipoLog.DETALHADO);
            // Se estiver apenas vizualizando os campos de entrada são desativados para edição
            SetaEnableEntradas(tarefa != Tarefa.VISUALIZANDO);
            if (project == null)
                return;
            else if (project.Empty)
            {
                tbx_analista.Text = tbx_descricao.Text = tbx_nomeProjeto.Text = tbx_programador.Text = tbx_rrm.Text = tbx_tester.Text = "";
                return;
            }

            tbx_numero_tarefa.Text = project.NumeroTarefa.ToString();
            tbx_analista.Text = project.NomeAnalista;
            tbx_descricao.Text = project.Descricao;
            tbx_nomeProjeto.Text = project.Nome;
            tbx_programador.Text = project.NomeProgramador;
            tbx_rrm.Text = project.Diretorio_RRM;
            tbx_tester.Text = project.NomeTester;
            mtbx_versao.Text = project.VersaoSistema;
            rbt_correcao.Checked = project.Tipo == ProjType.CORRECAO;
            rbt_mudanca.Checked = project.Tipo == ProjType.MUDANCA;
            rbt_sfv.Checked = project.Produto == Sistema.SFV;
            rbt_flex.Checked = project.Produto == Sistema.FLEX;
        }

        /// <summary>
        /// Método que desabilita
        /// </summary>
        public void SetaEnableEntradas(bool edita)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.SetaEnableEntradas()", Util.Global.TipoLog.DETALHADO);
            tbx_analista.Enabled = tbx_descricao.Enabled = tbx_nomeProjeto.Enabled = tbx_programador.Enabled = tbx_tester.Enabled = tbx_numero_tarefa.Enabled =
                btn_selecionaRRM.Enabled = rbt_correcao.Enabled = rbt_mudanca.Enabled = mtbx_versao.Enabled = rbt_flex.Enabled = rbt_sfv.Enabled = edita;
            tbx_rrm.Enabled = false;
        }

        /// <summary>
        /// Método que valida se os campos estão preenchidos corretamente
        /// </summary>
        /// <returns>True - PReenchidos corretamente; False - Campo com erro</returns>
        public bool ValidaCampos(ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.ValidaCampos()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            bool valor = true;

            if (string.IsNullOrEmpty(tbx_numero_tarefa.Text))
            {
                mensagemErro = "Campo \"Nome do Projeto\" está em branco!";
                tbx_numero_tarefa.Focus();
            }
            else if (string.IsNullOrEmpty(tbx_nomeProjeto.Text))
            {
                mensagemErro = "Campo \"Nome do Projeto\" está em branco!";
                tbx_nomeProjeto.Focus();
            }
            else if (string.IsNullOrEmpty(tbx_descricao.Text))
            {
                mensagemErro = "Campo \"Descrição do Projeto\" está em branco!";
                tbx_descricao.Focus();
            }
            else if (string.IsNullOrEmpty(tbx_analista.Text))
            {
                mensagemErro = "Campo \"Analista de Negócios\" está em branco!";
                tbx_analista.Focus();
            }
            else if (string.IsNullOrEmpty(tbx_programador.Text))
            {
                mensagemErro = "Campo \"Programador\" está em branco!";
                tbx_programador.Focus();
            }
            else if (string.IsNullOrEmpty(tbx_tester.Text))
            {
                mensagemErro = "Campo \"Tester\" está em branco!";
                tbx_tester.Focus();
            }
            else if (rbt_mudanca.Checked && string.IsNullOrEmpty(tbx_rrm.Text))
            {
                mensagemErro = "O \"RRM\" não foi selecionado! Todo projeto do tipo mudança precisa de um RRM!";
                btn_selecionaRRM.Focus();
            }

            return valor;
        }

        /// <summary>
        /// Método que faz a inclusão do projeto
        /// </summary>
        public void Incluir()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.Incluir()", Util.Global.TipoLog.DETALHADO);
            string mensagemErro = "";
            if(!ValidaCampos(ref mensagemErro))
            {
                MessageBox.Show(mensagemErro);
                return;
            }

            project.Nome = tbx_nomeProjeto.Text;
            project.NumeroTarefa = int.Parse(tbx_numero_tarefa.Text);
            project.Descricao = tbx_descricao.Text;
            project.DataCriacao = DateTime.Now;
            project.Diretorio_RRM = project.CopiaArquivo(tbx_rrm.Text);
            project.NomeProgramador = tbx_programador.Text;
            project.NomeAnalista = tbx_analista.Text;
            project.NomeTester = tbx_tester.Text;
            project.Tipo = rbt_mudanca.Checked ? ProjType.MUDANCA : ProjType.CORRECAO;
            project.Produto = rbt_sfv.Checked ? Sistema.SFV : Sistema.FLEX;
            project.VersaoSistema = mtbx_versao.Text;

            bool retorno = true;
            if (tarefa == Tarefa.INCLUINDO)
                retorno = project.Insert();
            else if (tarefa == Tarefa.EDITANDO)
                retorno = project.Update();

            if (retorno)
            {
                MessageBox.Show("Incluído com sucesso!");
                tarefa = Tarefa.VISUALIZANDO;
                principal.CarregaTreeView();
                CarregaLabels();
                CarregaBotoes();
            }
            else
            {
                MessageBox.Show("Erro ao inserir!");
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão cancelar
        /// </summary>
        public void Cancelar()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.Cancelar()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.INCLUINDO)
            {
                FechaTela();
            }
            else if(tarefa == Tarefa.EDITANDO)
            {
                tarefa = Tarefa.VISUALIZANDO;
                CarregaBotoes();
                CarregaLabels();
            }
        }

        /// <summary>
        /// Método que abre diálogo para seleção do caminho das imagens
        /// </summary>
        public void OpenDirectoryFile()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.OpenDirectoryFile()", Util.Global.TipoLog.DETALHADO);
            OpenFileDialog dialog_f = new OpenFileDialog();
            dialog_f.Multiselect = false;

            if (dialog_f.ShowDialog() == DialogResult.OK)
                this.tbx_rrm.Text = dialog_f.FileName.ToString();
            
        }

        /// <summary>
        /// Método que fecha o user control
        /// </summary>
        public void FechaTela()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.FechaTela()", Util.Global.TipoLog.DETALHADO);
            principal.FecharTela((Telas)this.Tag);
            this.Dispose();
        }

        /// <summary>
        /// Método que gera o relatório
        /// </summary>
        /// <param name="estimativa"></param>
        public void GeraRelatorio(bool estimativa)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroProjeto.GeraRelatorio", Util.Global.TipoLog.DETALHADO);
            lockchange = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecione o diretório de saída. O pdf será salvo no diretório selecionado com o nome: saida.pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FO_Agurade agurade = new FO_Agurade("Carregando relatório de testes!");
            agurade.Show();
            string mensagemErro = "";
            bool resultado = Util.Document.CriaRelatorioCompleto(project, dialog.SelectedPath, ref mensagemErro, estimativa);
            agurade.Close();

            if (resultado)
            {
                MessageBox.Show("Relatório de testes criado com sucesso! Saída: " + dialog.SelectedPath + "\\saida.pdf");
                if (MessageBox.Show("Deseja abrir o arquivo de saída?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Util.Document.ExecutaFile(dialog.SelectedPath + "\\saida.pdf", false, ref mensagemErro);
                }
            }
            else
                MessageBox.Show("Erro ao gerar o relatório!");

            lockchange = false;
        }

        #endregion Métodos        

    }
}
